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

using System.ComponentModel;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

using Ext.Net.Utilities;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public abstract partial class BaseFilter : Stream
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected const string VIEWSTATE = "<input type=\"hidden\" name=\"__VIEWSTATE\" id=\"__VIEWSTATE\" value=\"";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected const string VIEWSTATEENCRYPTED = "<input type=\"hidden\" name=\"__VIEWSTATEENCRYPTED\" id=\"__VIEWSTATEENCRYPTED\" value=\"";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected const string EVENTVALIDATION = "<input type=\"hidden\" name=\"__EVENTVALIDATION\" id=\"__EVENTVALIDATION\" value=\"";
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class AjaxRequestFilter : BaseFilter
    {
        private readonly Stream response;
        private readonly StringBuilder html;

        private static string GetHiddenInputValue(string html, string marker)
        {
            string value = null;
            int i = html.IndexOf(marker);

            if (i != -1)
            {
                value = html.Substring(i + marker.Length);
                value = value.Substring(0, value.IndexOf('\"'));
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stream"></param>
        [Description("")]
        public AjaxRequestFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        [Description("")]
        public override void Write(byte[] buffer, int offset, int count)
        {
            this.html.Append(HttpContext.Current.Response.ContentEncoding.GetString(buffer, offset, count));
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override void Flush()
        {
            string raw = this.html.ToString();

            StringBuilder buffer = new StringBuilder(256);

            DirectResponse ajaxResponse = new DirectResponse(true);
            HttpContext context = HttpContext.Current;

            object isUpdate = context.Items["Ext.Net.Direct.Update"];

            if (isUpdate != null && (bool)isUpdate)
            {
                this.ExtractUpdates(raw, ref buffer);
            }

            string dynamicHtml = this.ExtractDynamicHtml(raw);

            object isManual = context.Items["Ext.Net.Direct.Response.Manual"];

            if (isManual != null && (bool)isManual)
            {
                if (raw.StartsWith("<Ext.Net.Direct.Response.Manual>"))
                {
                    string script = dynamicHtml.ConcatWith(raw.RightOf("<Ext.Net.Direct.Response.Manual>").LeftOf("</Ext.Net.Direct.Response.Manual>"));
                    byte[] rsp = System.Text.Encoding.UTF8.GetBytes(script);
                    this.response.Write(rsp, 0, rsp.Length);
                    this.response.Flush();
                    return;
                }
            }

            buffer.Append(dynamicHtml);

            string error = context == null ? null : (context.Error != null ? context.Error.ToString() : null);
            
            if (!ResourceManager.AjaxSuccess || error.IsNotEmpty())
            {
                ajaxResponse.Success = false;

                if (error.IsNotEmpty())
                {
                    ajaxResponse.ErrorMessage = error; 
                }
                else
                {
                    ajaxResponse.ErrorMessage = ResourceManager.AjaxErrorMessage; 
                }
            }
            else
            {
                if (ResourceManager.ReturnViewState)
                {
                    ajaxResponse.ViewState = AjaxRequestFilter.GetHiddenInputValue(raw, BaseFilter.VIEWSTATE);
                    ajaxResponse.ViewStateEncrypted = AjaxRequestFilter.GetHiddenInputValue(raw, BaseFilter.VIEWSTATEENCRYPTED);
                    ajaxResponse.EventValidation = AjaxRequestFilter.GetHiddenInputValue(raw, BaseFilter.EVENTVALIDATION);
                }

                object obj = ResourceManager.ServiceResponse;

                if (obj is Response)
                {
                    ajaxResponse.ServiceResponse = new ClientConfig().Serialize(obj);
                }
                else
                {
                    ajaxResponse.ServiceResponse = obj != null ? JSON.Serialize(obj) : null;
                }

                if (ResourceManager.ExtraParamsResponse.Count > 0)
                {
                    ajaxResponse.ExtraParamsResponse = ResourceManager.ExtraParamsResponse.ToJson();
                }

                if (ResourceManager.DirectMethodResult != null)
                {
                    ajaxResponse.Result = ResourceManager.DirectMethodResult;
                }

                buffer.Append(raw.RightOf("<Ext.Net.Direct.Response>").LeftOf("</Ext.Net.Direct.Response>"));

                if (buffer.Length > 0)
                {
                    ajaxResponse.Script = "<string>".ConcatWith(buffer.ToString());
                }
            }

            bool isUpload = context != null && RequestManager.HasInputFieldMarker(context.Request);

            byte[] data = System.Text.Encoding.UTF8.GetBytes((isUpload ? "<textarea>" : "") + ajaxResponse.ToString() + (isUpload ? "</textarea>" : "") );
            this.response.Write(data, 0, data.Length);
            
            this.response.Flush();
        }

        private static Regex DynamicHtml_RE = new Regex(string.Concat(XControl.TOP_DYNAMIC_CONTROL_TAG_S, "(.*?)", XControl.TOP_DYNAMIC_CONTROL_TAG_E), RegexOptions.Compiled | RegexOptions.Singleline);
        
        private string ExtractDynamicHtml(string html)
        {
            StringBuilder sb = new StringBuilder(256);

            //MatchCollection m1 = Regex.Matches(html, string.Concat(XControl.TOP_DYNAMIC_CONTROL_TAG_S, "(.*?)", XControl.TOP_DYNAMIC_CONTROL_TAG_E), RegexOptions.Singleline);
            MatchCollection m1 = DynamicHtml_RE.Matches(html);

            foreach (Match m in m1)
            {
                sb.Append(m.Groups[1].Value);
            }

            return sb.ToString() ?? "";
        }

        private static Regex ExtractUpdates_RE = new Regex("<Ext.Net.Direct.Update id=\\\"(?<id>\\w*[^\"])+\\\"[^<]*>(?<html>.*?)</Ext.Net.Direct.Update>", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.IgnoreCase);
        
        private void ExtractUpdates(string html, ref StringBuilder buffer)
        {
            MatchCollection m1 = ExtractUpdates_RE.Matches(html);

            string tpl = "Ext.net.replaceWith({{id:\"{0}\",html:\"{1}\"}});";

            foreach (Match m in m1)
            {
                buffer.AppendFormat(tpl, m.Groups["id"], m.Groups["html"].Value.StripWhitespaceChars().StripExtraSpaces().Enquote());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool CanRead
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool CanSeek
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override bool CanWrite
        {
            get { return true; }
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override void Close()
        {
            this.response.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override long Length
        {
            get { return 0; }
        }

        private long position;

        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public override long Position
        {
            get
            {
                return this.position;
            }
            set
            {
                this.position = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="offset"></param>
        /// <param name="origin"></param>
        /// <returns></returns>
        [Description("")]
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="length"></param>
        [Description("")]
        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        [Description("")]
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}