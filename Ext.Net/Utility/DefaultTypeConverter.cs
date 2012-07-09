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
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class DefaultTypeConverter : StringConverter
    {
        private static Dictionary<string, string> xtypesDictionary = new Dictionary<string,string>()
        {
            { "BoxComponent", "box" },
            { "Button", "button" },
            { "ButtonGroup", "buttongroup" },
            { "CalendarPanel", "calendarpanel" },
            { "CheckMenuItem", "menucheckitem" },
            { "Checkbox", "checkbox" },
            { "CheckboxGroup", "checkboxgroup" },
            { "ColorMenu", "colormenu" },
            { "ColorPallete", "colorpalette" },
            { "ColumnTree", "columntree" },
            { "ComboBox", "combo" },
            { "Component", "component" },
            { "ComponentMenuItem", "componentmenuitem" },
            { "CompositeField", "compositefield" },
            { "Container", "container" },
            { "CycleButton", "cycle" },
            { "DataView", "dataview" },
            { "DateField", "datefield" },
            { "DateMenu", "datemenu" },
            { "DatePicker", "datepicker" },
            { "DisplayField", "displayfield" },
            { "DropDownField", "netdropdown" },
            { "FieldSet", "fieldset" },
            { "FileUploadField", "fileuploadfield" },
            { "FlashComponent", "flash" },
            { "FormPanel", "form" },
            { "GridPanel", "netgrid" },
            { "GroupTab", "grouptab" },
            { "GroupTabPanel", "grouptabpanel" },
            { "HiddenField", "hidden" },
            { "HtmlEditor", "htmleditor" },
            { "HyperLink", "nethyperlink" },
            { "Image", "netimage" },
            { "ImageButton", "netimagebutton" },
            { "Label", "label" },
            { "LinkButton", "netlinkbutton" },
            { "ListView", "listview" },
            { "Menu", "menu" },
            { "MenuItem", "menuitem" },
            { "MenuSeparator", "menuseparator" },
            { "MenuTextItem", "menutextitem" },
            { "MultiSelect", "multiselect" },
            { "MenuPanel", "netmenupanel" },
            { "MultiCombo", "netmulticombo" },
            { "NumberFIeld", "numberfield" },
            { "PropertyGrid", "netpropertygrid" },
            { "Panel", "panel" },
            { "Portal", "portal" },
            { "Portlet", "portlet" },
            { "ProgressBar", "progress" },
            { "Radio", "radio" },
            { "RadioGroup", "radiogroup" },
            { "SelectBox", "selectbox" },
            { "Slider", "slider" },
            { "SliderField", "sliderfield" },
            { "SpinnerField", "spinnerfield" },
            { "SplitButton", "splitbutton" },
            { "StatusBar", "statusbar" },
            { "Toolbar.HtmlElement", "nettbhtml" },
            { "Toolbar.Spacer", "nettbspacer" },
            { "TreePanel", "nettreepanel" },
            { "TriggerField", "nettrigger" },
            { "TableGrid", "tablegrid" },
            { "TabPanel", "tabpanel" },
            { "TabStrip", "tabstrip" },
            { "Toolbar.Fill", "tbfill" },
            { "Toolbar.Separator", "tbseparator" },
            { "Toolbar.TextItem", "tbtext" },
            { "TextArea", "textarea" },
            { "TextField", "textfield" },
            { "TimeField", "timefield" },
            { "Toolbar", "toolbar" },
            { "TreeGrid", "treegrid" }
        };

        private TypeConverter.StandardValuesCollection values;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (this.values == null)
            {
                this.values = new TypeConverter.StandardValuesCollection(xtypesDictionary.Keys);
            }

            return this.values;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [Description("")]
        public static string GetXType(string value)
        {
            string xtype;
            xtypesDictionary.TryGetValue(value, out xtype);
            return xtype ?? value;
        }
    }
}