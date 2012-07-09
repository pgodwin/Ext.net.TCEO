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
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Text;
using System.Web.UI;
using System.Web.UI.Design;

using Ext.Net.Utilities;

namespace Ext.Net
{
	/// <summary>
	/// 
	/// </summary>
	[Description("")]
    public partial class ContentPanelDesigner : PanelBaseDesigner
    {
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void Initialize(System.ComponentModel.IComponent component)
        {
            base.Initialize(component);

            if (!this.Disabled)
            {
                this.SetViewFlags(ViewFlags.TemplateEditing, true);
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override TemplateGroupCollection TemplateGroups
        {
            get
            {
                TemplateGroupCollection templateGroups = new TemplateGroupCollection();
                TemplateGroup group = new TemplateGroup("Body");
                TemplateDefinition template = new TemplateDefinition(this, "Body", this.Control, "Body", false);
                group.AddTemplateDefinition(template);
                templateGroups.Add(group);
                return templateGroups;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string GetEditableDesignerRegionContent(EditableDesignerRegion region)
        {
            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));

            if (host != null)
            {
                ITemplate template = ((Component)this.Control).Content as ITemplate;

                if (template != null)
                {
                    return ControlPersister.PersistTemplate(template, host);
                }
            }

            return "";
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override void SetEditableDesignerRegionContent(EditableDesignerRegion region, string content)
        {
            if (content == null)
            {
                return;
            }

            IDesignerHost host = (IDesignerHost)Component.Site.GetService(typeof(IDesignerHost));

            if (host != null)
            {
                ITemplate template = ControlParser.ParseTemplate(host, content);
                ((IContent)this.Control).Content = template;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        protected string ContentRegionName
        {
            get
            {
                if (Layout.HasValue)
                {
                    switch (Layout.Value)
                    {
                        case LayoutType.Accordion:
                            break;
                        case LayoutType.Anchor:
                            break;
                        case LayoutType.Border:
                            return "Body_{0}_{1}".FormatWith(BorderRegion.Region, 0);
                        case LayoutType.Card:
                            break;
                        case LayoutType.Column:
                            break;
                        case LayoutType.Container:
                            break;
                        case LayoutType.Fit:
                            return "Body_{0}".FormatWith(0);
                        case LayoutType.Form:
                            break;
                        case LayoutType.Table:
                            break;
                    }
                }

                return "Body";
            }
        }
        
    }
}