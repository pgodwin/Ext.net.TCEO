/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 1.2.0 - Ext.NET Pro License
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2011-09-12
 * @copyright : Copyright (c) 2006-2011, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.Design;
using System.Xml;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class InitializationScriptNotFoundException : NullReferenceException
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        [Description("")]
        public InitializationScriptNotFoundException(string errorMessage)
            : base(errorMessage) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <param name="inner"></param>
        [Description("")]
        public InitializationScriptNotFoundException(string errorMessage, Exception inner)
            : base(errorMessage, inner) { }
    }

    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal)]
    internal class ResourceHandler : Page, IHttpHandler, IRequiresSessionState
    {
        Stream stream;
        ResourceManager sm;
        StringBuilder sb;
        HttpContext context;
        string webResource;
        byte[] output;
        int length;
        bool compress;
        
        private static long GetAssemblyTime(Assembly assembly)
        {
            AssemblyName assemblyName = assembly.GetName();

            return File.GetLastWriteTime(new Uri(assemblyName.CodeBase).LocalPath).Ticks;
        }

        private static bool IsSourceModified(HttpRequest request)
        {
            bool dateModified = false;

            string requestIfModifiedSinceHeader = request.Headers["If-Modified-Since"] ?? string.Empty;
            DateTime requestIfModifiedSince;
            DateTime.TryParse(requestIfModifiedSinceHeader, out requestIfModifiedSince);

            DateTime responseLastModified = new DateTime(ResourceHandler.GetAssemblyTime(typeof(ResourceHandler).Assembly)).ToUniversalTime();

            if (requestIfModifiedSince != DateTime.MinValue && responseLastModified != DateTime.MinValue)
            {
                requestIfModifiedSince = requestIfModifiedSince.ToUniversalTime();

                if (responseLastModified > requestIfModifiedSince)
                {
                    TimeSpan diff = responseLastModified - requestIfModifiedSince;
                    if (diff > TimeSpan.FromSeconds(1))
                    {
                        dateModified = true;
                    }
                }
            }
            else
            {
                dateModified = true;
            }           

            return dateModified;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        [Description("")]
        public override void ProcessRequest(HttpContext context)
        {
            this.context = context;
            
            string file = this.context.Request.RawUrl;

            bool isInitScript = file.Contains("extnet/extnet-init-js/ext.axd?");

            if ((!isInitScript && !ResourceHandler.IsSourceModified(context.Request)) || (isInitScript && !string.IsNullOrEmpty(context.Request.Headers["If-Modified-Since"])))
            {
                context.Response.SuppressContent = true;
                context.Response.StatusCode = 304;
                context.Response.StatusDescription = "Not Modified";
                context.Response.AddHeader("Content-Length", "0");
                return;
            }            
            
            this.SetResponseCache(context);

            if (isInitScript)
            {
                string key = file.RightOfRightmostOf('?');

                if (key.IsNotEmpty())
                {
                    try
                    {
                        string script = this.context.Session[key].ToString();
                        this.context.Session.Remove(key);                        
                        CompressionUtils.GZipAndSend(script);
                    }
                    catch (NullReferenceException)
                    {
                        throw new InitializationScriptNotFoundException("The Ext.NET initialization script was not found.");
                    }
                }
            }
            else
            {
                try
                {
                    this.sm = new ResourceManager();
                    this.compress = CompressionUtils.IsGZipSupported && this.sm.GZip;

                    this.SetWebResourceName(file);

                    this.stream = this.GetType().Assembly.GetManifestResourceStream(this.webResource);
                    string ext = this.webResource.RightOfRightmostOf('.');
                    this.compress = this.compress && !this.IsImage(ext);

                    switch (ext)
                    {
                        case "js":
                            this.WriteFile("text/javascript");
                            break;
                        case "css":
                            this.WriteFile("text/css");
                            break;

                        case "gif":
                            this.WriteImage("image/gif");
                            break;
                        case "png":
                            this.WriteImage("image/png");
                            break;
                        case "jpg":
                        case "jpeg":
                            this.WriteImage("image/jpg");
                            break;
                    }
                }
                catch (Exception e)
                {
                    string s = this.IsDebugging ? e.ToString() : e.Message;
                    context.Response.StatusDescription = s.Substring(0, Math.Min(s.Length, 512));
                    this.context.Response.Redirect(Page.ClientScript.GetWebResourceUrl(this.sm.GetType(), this.webResource));
                }
                finally
                {
                    if (this.stream != null)
                    {
                        this.stream.Close();
                    }
                }
            }
        }

        private bool IsImage(string ext)
        {
            return ext == "gif" || ext == "png" || ext == "jpg" || ext == "jpeg";
        }

        private bool IsDebugging
        {
            get
            {
                bool result = false;

                if (HttpContext.Current != null)
                {
                    result = HttpContext.Current.IsDebuggingEnabled;
                }

                return result;
            }
        }

        private void SetResponseCache(HttpContext context)
        {
            HttpCachePolicy cache = context.Response.Cache;
            DateTime modifiedDate = new DateTime(ResourceHandler.GetAssemblyTime(typeof(ResourceHandler).Assembly)).ToUniversalTime();
            DateTime nowDate = DateTime.Now.ToUniversalTime().AddSeconds(-1);

            if (modifiedDate > nowDate)
            {
                modifiedDate = nowDate;
            }

            cache.SetLastModified(modifiedDate);
            cache.SetOmitVaryStar(true);
            cache.SetVaryByCustom("v");
            cache.SetExpires(DateTime.UtcNow.AddDays(365));
            cache.SetMaxAge(TimeSpan.FromDays(365));
            cache.SetValidUntilExpires(true);
            cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            cache.SetCacheability(HttpCacheability.Public);
            cache.SetLastModifiedFromFileDependencies();
        }

        private void WriteFile(string responseType)
        {
            this.output = this.GetCache();

            if (this.output != null)
            {
                this.Send(this.output, responseType);
                
                return;
            }

            this.sb = new StringBuilder(4096);

            using (this.stream)
            {
                StreamReader reader = new StreamReader(this.stream);
                this.sb.Append(reader.ReadToEnd());
                reader.Close();
            }

            string data = responseType == "text/css"
                              ? this.sm.ParseCssWebResourceUrls(this.sb.ToString())
                              : this.sb.ToString();

            byte[] content = this.compress ? CompressionUtils.GZip(data) : Encoding.UTF8.GetBytes(data);


            this.SetCache(content);

            this.Send(content, responseType);
            
        }

        private void Send(byte[] data, string responseType)
        {
            if(this.compress)
            {
                CompressionUtils.Send(data, responseType);
            }
            else
            {
                HttpResponse response = HttpContext.Current.Response;

                response.Charset = "utf-8";
                response.ContentType = responseType;
                response.BinaryWrite(data);    
            }
        }

        private void WriteImage(string responseType)
        {
            this.output = this.GetCache();

            if (this.output == null)
            {
                this.length = Convert.ToInt32(this.stream.Length);
                this.output = new Byte[this.length];
                this.stream.Read(this.output, 0, this.length);

                this.SetCache(this.output);
            }

            this.Send(this.output, responseType);
        }

        private byte[] GetCache()
        {
            return this.context.Cache[this.webResource + (this.compress ? "_gzip" : "_nonegzip")] as byte[];
        }

        private void SetCache(byte[] content)
        {
            this.context.Cache.Insert(this.webResource + (this.compress ? "_gzip" : "_nonegzip"), content, null, System.Web.Caching.Cache.NoAbsoluteExpiration, TimeSpan.FromDays(30));
        }     
        
        private void SetWebResourceName(string filePath)
        {
            this.webResource = filePath.LeftOfRightmostOf("/ext.axd").RightOf(this.sm.ApplicationName).Insert(0, ResourceManager.ASSEMBLYSLUG).Replace('/', '.').ReplaceLastInstanceOf("-", ".");
        }

        new public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public static bool HasModule()
        {
            if (HttpContext.Current.Application["HasModule"] != null)
            {
                return (bool)HttpContext.Current.Application["HasModule"];
            }

            bool result = false;
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "web.config");
            XmlTextReader reader = new XmlTextReader(new StreamReader(path));

            try
            {
                if (reader.ReadToFollowing("httpModules"))
                {
                    if (reader.ReadInnerXml().Contains("type=\"Ext.Net.DirectRequestModule"))
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                reader.Close();
            }

            HttpContext.Current.Application["HasModule"] = result;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [Description("")]
        public static bool HasHandler()
        {
            if (HttpContext.Current.Application["HasHandler"] != null)
            {
                return (bool)HttpContext.Current.Application["HasHandler"];
            }

            bool result = false;
            string path = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "web.config");
            XmlTextReader reader = new XmlTextReader(new StreamReader(path));

            try
            {
                if (reader.ReadToFollowing("httpHandlers"))
                {
                    if (reader.ReadInnerXml().Contains("type=\"Ext.Net.ResourceHandler\""))
                    {
                        result = true;
                    }
                }
            }
            catch
            {
                result = false;
            }
            finally
            {
                reader.Close();
            }

            HttpContext.Current.Application["HasHandler"] = result;

            return result;
        }

        internal static void CheckConfiguration(ISite site)
        {
            if (site == null)
            {
                return;
            }

            IWebApplication app = (IWebApplication)site.GetService(typeof(IWebApplication));

            if (app == null)
            {
                return;
            }

            Configuration config = app.OpenWebConfiguration(false);

            HttpHandlersSection handlers = (HttpHandlersSection)config.GetSection("system.web/httpHandlers");

            // Does the httpHandlers Secton already exist?
            if (handlers == null)
            {
                // If not, add it...
                handlers = new HttpHandlersSection();

                ConfigurationSectionGroup group = config.GetSectionGroup("system.web");

                // Does the system.web Section already exist?
                if (group == null)
                {
                    // If not, add it...
                    config.SectionGroups.Add("system.web", new ConfigurationSectionGroup());
                    group = config.GetSectionGroup("system.web");
                }

                if (group != null)
                {
                    group.Sections.Add("httpHandlers", handlers);
                }
            }

            HttpHandlerAction action = new HttpHandlerAction("*/ext.axd", "Ext.Net.ResourceHandler", "*", false);

            // Does the ResourceHandler already exist?
            if (handlers.Handlers.IndexOf(action) < 0)
            {
                // If not, add it...
                handlers.Handlers.Add(action);
                config.Save();
            }

            HttpModulesSection modules = (HttpModulesSection)config.GetSection("system.web/httpModules");

            // Does the httpModules Secton already exist?
            if (modules == null)
            {
                // If not, add it...
                modules = new HttpModulesSection();

                ConfigurationSectionGroup group = config.GetSectionGroup("system.web");

                // Does the system.web Section already exist?
                if (group == null)
                {
                    // If not, add it...
                    config.SectionGroups.Add("system.web", new ConfigurationSectionGroup());
                    group = config.GetSectionGroup("system.web");
                }

                if (group != null)
                {
                    group.Sections.Add("httpModules", modules);
                }
            }


            //<add name="DirectRequestModule" type="Ext.Net.DirectRequestModule, Ext.Net" />

            HttpModuleAction action2 = new HttpModuleAction("DirectRequestModule", "Ext.Net.DirectRequestModule, Ext.Net");

            // Does the ResourceHandler already exist?
            if (modules.Modules.IndexOf(action2) < 0)
            {
                // If not, add it...
                modules.Modules.Add(action2);
                config.Save();
            }
        }
    }
}