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

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public abstract partial class ResourceItem
    {
        private Type type = typeof(ResourceManager);
        private string pathEmbedded;
        private string path = "";
        private string cacheFly;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Type Type
        {
            get 
            { 
                return this.type; 
            }
            internal set 
            { 
                this.type = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PathEmbedded
        {
            get 
            { 
                return this.pathEmbedded; 
            }
            internal set 
            { 
                this.pathEmbedded = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string CacheFly
        {
            get
            {
                return this.cacheFly;
            }
            internal set
            {
                this.cacheFly = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string Path
        {
            get
            {
                if (this.path.IsEmpty())
                {
                    this.path = this.PathEmbedded.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", ".");
                }

                return this.path;
            }
            internal set
            {
                this.path = value;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public sealed class ClientStyleItem : ResourceItem
    {
        private Theme theme = Theme.Default;

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public Theme Theme
        {
            get 
            { 
                return this.theme; 
            }
            internal set 
            { 
                this.theme = value; 
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path) : this(pathEmbedded, path)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path, string cacheFly) : this(type, pathEmbedded, path)
        {
            this.CacheFly = cacheFly;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path, string cacheFly, Theme theme) : this(type, pathEmbedded, path, cacheFly)
        {
            this.Theme = theme;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(Type type, string pathEmbedded, string path, Theme theme) : this(type, pathEmbedded, path)
        {
            this.Theme = theme;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path)
        {
            this.PathEmbedded = pathEmbedded;
            this.Path = path;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path, string cacheFly)
            : this(pathEmbedded, path)
        {
            this.CacheFly = cacheFly;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path, string cacheFly, Theme theme)
            : this(pathEmbedded, path, cacheFly)
        {
            this.Theme = theme;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientStyleItem(string pathEmbedded, string path, Theme theme)
            : this(pathEmbedded, path)
        {
            this.Theme = theme;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public sealed class ClientScriptItem : ResourceItem
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string path)
        {
            this.PathEmbedded = pathEmbedded;
            this.Path = path;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string path, string cacheFly)
            : this(pathEmbedded, path)
        {
            this.CacheFly = cacheFly;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug)
            : this(pathEmbedded, path)
        {
            this.PathEmbeddedDebug = pathEmbeddedDebug;
            this.PathDebug = pathDebug;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug, string cacheFly)
            : this(pathEmbedded, pathEmbeddedDebug, path, pathDebug)
        {
            this.CacheFly = cacheFly;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string path)
            : this(pathEmbedded, path)
        {
            this.Type = type;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string path, string cacheFly)
            : this(type, pathEmbedded, path)
        {
            this.CacheFly = cacheFly;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug)
            : this(type, pathEmbedded, path)
        {
            this.PathEmbeddedDebug = pathEmbeddedDebug;
            this.PathDebug = pathDebug;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public ClientScriptItem(Type type, string pathEmbedded, string pathEmbeddedDebug, string path, string pathDebug, string cacheFly)
            : this(type, pathEmbedded, pathEmbeddedDebug, path, pathDebug)
        {
            this.CacheFly = cacheFly;
        }

        private string pathEmbeddedDebug;
        
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public string PathEmbeddedDebug
        {
            get 
            { 
                return this.pathEmbeddedDebug; 
            }
            internal set 
            { 
                this.pathEmbeddedDebug = value; 
            }
        }

        private string pathDebug = "";

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public string PathDebug
        {
            get
            {
                if (this.pathDebug.IsEmpty())
                {
                    this.pathDebug = this.PathEmbeddedDebug.Replace(ResourceManager.ASSEMBLYSLUG, "").Replace('.', '/').ReplaceLastInstanceOf("/", ".");
                }

                return this.pathDebug;
            }
            internal set
            {
                this.pathDebug = value;
            }
        }
    }
}