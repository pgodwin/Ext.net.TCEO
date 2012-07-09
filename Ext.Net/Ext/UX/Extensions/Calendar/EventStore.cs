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
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    public partial class EventStore : Store
    {
        /// <summary>
        /// 
        /// </summary>
        public override ConfigOptionsExtraction ConfigOptionsExtraction
        {
            get
            {
                return CalendarPanel.ConfigOptionsEngine;
            }
        }
        
        /// <summary>
        /// 
        /// </summary>
        //public override bool IsDefault
        //{
        //    get
        //    {
        //        return this.Events.Count == 0 && this.Proxy.Count == 0;
        //    }
        //}

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            this.EnsureReader();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        protected override void OnBeforeClientInit(Observable sender)
        {
            base.OnBeforeClientInit(sender);

            if (this.AutoLoad)
            {
                this.AutoLoad = false;
                this.CustomConfig.Add(new ConfigItem("deferLoad", "true", ParameterMode.Raw));
            }

            if (this.StandardFields)
            {
                this.AddStandardFields();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void EnsureReader()
        {
            if (this.Reader.Count == 0)
            {
                this.Reader.Add(new JsonReader { IDProperty = "EventId" });
            }
        }

        /// <summary>
        /// The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').
        /// </summary>
        [Meta]
        [Category("3. EventStore")]
        [DefaultValue(null)]
        [Description("The default date format string which can be overriden for localization support. The format must be valid according to Date.parseDate (defaults to 'd').")]
        public virtual string DateFormat
        {
            get
            {
                return (string)this.ViewState["DateFormat"] ?? null;
            }
            set
            {
                this.ViewState["DateFormat"] = value;
            }
        }

        protected override string GetAjaxDataJson()
        {
            if (this.Proxy.Count == 0 && this.Events.Count > 0)
            {
                return JSON.Serialize(this.Events);
            }

            return base.GetAjaxDataJson();
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("proxy", JsonMode.Raw)]
        [DefaultValue("")]
        [Description("")]
        protected override string MemoryProxy
        {
            get
            {
                if (this.Proxy.Count == 0 && this.Events.Count > 0)
                {
                    string template = "new Ext.data.PagingMemoryProxy({0}, false)";
                    return string.Format(template, JSON.Serialize(this.Events));
                }

                return base.MemoryProxy;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void AddStandardFields()
        {
            this.EnsureReader();
            this.Reader[0].Fields.Add(new RecordField { Name = "EventId", Type = RecordFieldType.Int });
            this.Reader[0].Fields.Add(new RecordField { Name = "CalendarId", Type = RecordFieldType.Int });
            this.Reader[0].Fields.Add(new RecordField { Name = "Title", Type = RecordFieldType.String });
            this.Reader[0].Fields.Add(new RecordField { Name = "StartDate", Type = RecordFieldType.Date, DateFormat = this.DateFormat });
            this.Reader[0].Fields.Add(new RecordField { Name = "EndDate", Type = RecordFieldType.Date, DateFormat = this.DateFormat });
            this.Reader[0].Fields.Add(new RecordField { Name = "Location", Type = RecordFieldType.String });
            this.Reader[0].Fields.Add(new RecordField { Name = "Notes", Type = RecordFieldType.String });
            this.Reader[0].Fields.Add(new RecordField { Name = "Url", Type = RecordFieldType.String });
            this.Reader[0].Fields.Add(new RecordField { Name = "IsAllDay", Type = RecordFieldType.Boolean });
            this.Reader[0].Fields.Add(new RecordField { Name = "Reminder", Type = RecordFieldType.String });
            this.Reader[0].Fields.Add(new RecordField { Name = "IsNew", Type = RecordFieldType.Boolean });
            this.StandardFields = false;
        }

        private EventCollection events;

        /// <summary>
        /// 
        /// </summary>
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [Description("")]        
        public virtual EventCollection Events
        {
            get
            {
                if (this.events == null)
                {
                    this.events = new EventCollection();
                }

                return this.events;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private bool standardFields = true;

        public virtual bool StandardFields
        {
            get
            {
                return this.standardFields;
            }
            set
            {
                this.standardFields = value;
            }
        }
    }    
}