/******** 
 * This file is part of Ext.Net UX.

 * Ext.Net UX is free software: you can redistribute it and/or modify
 * it under the terms of the GNU Lesser General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * Ext.Net UX is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU Lesser General Public License for more details.

 * You should have received a copy of the GNU Lesser General Public License
 * along with the Ext.Net.  If not, see <http://www.gnu.org/licenses/>.
 */

/*
* @version:		1.2.0
* @author:		Ext.NET, Inc. http://www.ext.net/
* @date:		2011-09-12
* @copyright:	Copyright (c) 2006-2011, Ext.NET, Inc. or as noted within each 
* 				applicable file LICENSE.txt file
* @license:		LGPL 3.0 License
* @website:		http://www.ext.net/
 ********/

using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Web.UI;
using Ext.Net;

[assembly: WebResource("Ext.Net.UX.Plugins.InputTextMask.resources.InputTextMask.js", "text/javascript")]

namespace Ext.Net.UX
{
    /** It creates a new input text mask.
     * @class InputTextMask is a plugin for Ext.form.TextField, used to add an input mask to the field.
     * Mask Individual Character Usage:
     * 
     * 9 - designates only numeric values
     * L - designates only uppercase letter values
     * l - designates only lowercase letter values
     * A - designates only alphanumeric values
     * X - denotes that a custom client script regular expression is specified
     *
     * All other characters are assumed to be "special" characters used to mask the input component.
     * Example 1:
     *    (999)999-9999 only numeric values can be entered where the the character
     *    position value is 9. Parenthesis and dash are non-editable/mask characters.
     * Example 2:
     *    99L-ll-X[^A-C]X only numeric values for the first two characters,
     *    uppercase values for the third character, lowercase letters for the
     *    fifth/sixth characters, and the last character X[^A-C]X together counts
     *    as the eighth character regular expression that would allow all characters
     *    but "A", "B", and "C". Dashes outside the regular expression are non-editable/mask characters.
    */

    [ToolboxBitmap(typeof(UX.InputTextMask), "Build.Resources.ToolboxIcons.Plugin.bmp")]
    [ToolboxData("<{0}:InputTextMask runat=\"server\" />")]
    [Description("InputTextMask plugin used for mask/regexp operations")]
    public partial class InputTextMask : Plugin
    {
        protected override List<ResourceItem> Resources
        {
            get
            {
                List<ResourceItem> baseList = base.Resources;
                baseList.Capacity += 1;

                baseList.Add(new ClientScriptItem(typeof(InputTextMask), "Ext.Net.UX.Plugins.InputTextMask.resources.InputTextMask.js", "ux/extensions/inputtextmask/inputtextmask.js"));

                return baseList;
            }
        }
        
        public override string InstanceOf
        {
            get
            {
                return "Ext.ux.netbox.InputTextMask";
            }
        }

        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("The InputTextMask")]
        public string Mask
        {
            get
            {
                object obj = this.ViewState["Mask"];
                return obj == null ? "" : (string)obj;
            }
            set
            {
                this.ViewState["Mask"] = value;
            }
        }

        [ConfigOption]
        [Category("Config Options")]
        [DefaultValue(true)]
        [NotifyParentProperty(true)]
        [Description("True to clear the mask when the field blurs and the text is invalid. Optional, default is true")]
        public bool ClearWhenInvalid
        {
            get
            {
                object obj = this.ViewState["ClearWhenInvalid"];
                return obj == null ? true : (bool)obj;
            }
            set
            {
                this.ViewState["ClearWhenInvalid"] = value;
            }
        }
    }
}
