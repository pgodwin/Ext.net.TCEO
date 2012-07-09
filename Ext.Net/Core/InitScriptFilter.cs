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
using System;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class InitScriptFilter : BaseFilter
    {
        private readonly Stream response;
        private readonly StringBuilder html;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string OPEN_SCRIPT_TAG = "<Ext.Net.InitScript>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string CLOSE_SCRIPT_TAG = "</Ext.Net.InitScript>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string OPEN_SCRIPT_FILES_TAG = "<Ext.Net.InitScriptFiles>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string CLOSE_SCRIPT_FILES_TAG = "</Ext.Net.InitScriptFiles>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string OPEN_STYLE_TAG = "<Ext.Net.InitStyle>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string CLOSE_STYLE_TAG = "</Ext.Net.InitStyle>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string OPEN_WARNING_TAG = "<Ext.Net.InitScript.Warning>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string CLOSE_WARNING_TAG = "</Ext.Net.InitScript.Warning>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string INIT_SCRIPT_PLACEHOLDER = "<Ext.Net.InitScriptPlaceholder />";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string INIT_SCRIPT_FILES_PLACEHOLDER = "<Ext.Net.ScriptFilesPlaceholder />";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string CONFIG_SCRIPT_PLACEHOLDER = "<Ext.Net.ConfigScriptPlaceholder />";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public const string INIT_STYLE_PLACEHOLDER = "<Ext.Net.InitStylePlaceholder />";
        //private const string REMOVE_VIEWSTATE_PATTERN = "<div>[\\r|\\t|\\s]*<input.*name=\"__EVENTVALIDATION\"[^>].*/>[\\r|\\t|\\s]*</div>|<input.*name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED)\"[^>].*/>|<script[^>]*>[\\w|\\t|\\r|\\W]*?function __doPostBack[\\w|\\t|\\r|\\W]*?</script>";
        private const string REMOVE_VIEWSTATE_PATTERN = "<div>[\\r|\\t|\\s]*<input.*name=\"__EVENTVALIDATION\"[^>].*/>[\\r|\\t|\\s]*</div>|<input.*name=\"__(VIEWSTATE|VIEWSTATEENCRYPTED)\"[^>].*/>";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public InitScriptFilter(Stream stream)
        {
            this.response = stream;
            this.html = new StringBuilder();
        }

		/// <summary>
		/// 
		/// </summary>
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
            if (this.html.Length == 0)
            {
                this.response.Flush();
                return;  
            }

            var start = DateTime.Now.Ticks;

            if (ResourceManager.DisableViewStateStatic)
            {
                this.RemoveViewState();
            }

            this.RemoveWarning();

            this.ReplacePlaceHolder(InitScriptFilter.INIT_SCRIPT_PLACEHOLDER, OPEN_SCRIPT_TAG, CLOSE_SCRIPT_TAG);
            this.ReplacePlaceHolder(InitScriptFilter.CONFIG_SCRIPT_PLACEHOLDER, OPEN_SCRIPT_TAG, CLOSE_SCRIPT_TAG);
            this.ReplacePlaceHolder(InitScriptFilter.INIT_SCRIPT_FILES_PLACEHOLDER, OPEN_SCRIPT_FILES_TAG, CLOSE_SCRIPT_FILES_TAG);
            this.ReplacePlaceHolder(InitScriptFilter.INIT_STYLE_PLACEHOLDER, OPEN_STYLE_TAG, CLOSE_STYLE_TAG);

            //var end = DateTime.Now.Ticks;
            //string ticksMsg = string.Format("ticks({0});", TimeSpan.FromTicks(end - start).TotalMilliseconds);
            //this.html.Replace("Ext.onReady(function(){", "Ext.onReady(function(){" + ticksMsg);

            byte[] data = System.Text.Encoding.UTF8.GetBytes(this.html.ToString());
            this.response.Write(data, 0, data.Length);
            this.response.Flush();
        }

        private static Regex ViewState_RE = new Regex(InitScriptFilter.REMOVE_VIEWSTATE_PATTERN, RegexOptions.Compiled | RegexOptions.IgnoreCase);

        private void RemoveViewState()
        {
            foreach (Match match in ViewState_RE.Matches(this.html.ToString()))
            {
                this.html.Replace(match.Value, "");
            }
        }

        private void RemoveWarning()
        {
            int start = this.html.ToString().IndexOf(InitScriptFilter.OPEN_WARNING_TAG);

            if (start >= 0)
            {
                int end = this.html.ToString().IndexOf(InitScriptFilter.CLOSE_WARNING_TAG) + InitScriptFilter.CLOSE_WARNING_TAG.Length;
                this.html.Remove(start, end - start);
            }
        }

        private void ReplacePlaceHolder(string placeHolderMarker, string openTag, string closeTag)
        {
            int index = this.html.ToString().IndexOf(placeHolderMarker);

            if (index >= 0)
            {
                string script = this.html.ToString().RightOf(openTag).LeftOf(closeTag);

                if (script.IsNotEmpty())
                {
                    int start = this.html.ToString().IndexOf(openTag);
                    int end = this.html.ToString().IndexOf(closeTag) + closeTag.Length;
                    this.html.Remove(start, end - start);

                    if (index > start)
                    {
                        index = this.html.ToString().IndexOf(placeHolderMarker);
                    }
                    
                    //Probably better perfomance because we don't need to search marker again, we know its index
                    this.html.Remove(index, placeHolderMarker.Length);
                    this.html.Insert(index, script);
                }
                else
                {
                    this.html.Remove(index, placeHolderMarker.Length);
                }
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
            get { return this.position; }
            set { this.position = value; }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override long Seek(long offset, SeekOrigin origin)
        {
            return this.response.Seek(offset, origin);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void SetLength(long length)
        {
            this.response.SetLength(length);
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override int Read(byte[] buffer, int offset, int count)
        {
            return this.response.Read(buffer, offset, count);
        }
    }
}