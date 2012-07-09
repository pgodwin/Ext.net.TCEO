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

using System.ComponentModel;
using Ext.Net;

namespace Ext.Net.UX
{
    public partial class MarkerOptions : StateManagedItem
    {
        [ConfigOption]
        [DefaultValue("")]
        [NotifyParentProperty(true)]
        [Description("This string will appear as tooltip on the marker")]
        public string Title
        {
            get
            {
                return (string)this.ViewState["Title"] ?? "";
            }
            set
            {
                this.ViewState["Title"] = value;
            }
        }


        /*
         Need to add
         GMarker class
           Properties           Type 	    Description
           -------------------  ----------  -----------------------------------------------------------------------------------
            icon                GIcon 	    Chooses the Icon for this class. If not specified, G_DEFAULT_ICON is used. (Since 2.50)
            dragCrossMove 	    Boolean 	When dragging markers normally, the marker floats up and away from the cursor. Setting this value to true keeps the marker underneath the cursor, and moves the cross downwards instead. The default value for this option is false. (Since 2.63)
            title 	            String 	    This string will appear as tooltip on the marker, i.e. it will work just as the title attribute on HTML elements. (Since 2.50)
            clickable 	        Boolean 	Toggles whether or not the marker is clickable. Markers that are not clickable or draggable are inert, consume less resources and do not respond to any events. The default value for this option is true, i.e. if the option is not specified, the marker will be clickable. (Since 2.50)
            draggable 	        Boolean 	Toggles whether or not the marker will be draggable by users. Markers set up to be dragged require more resources to set up than markers that are clickable. Any marker that is draggable is also clickable, bouncy and auto-pan enabled by default. The default value for this option is false. (Since 2.61)
            bouncy 	            Boolean 	Toggles whether or not the marker should bounce up and down after it finishes dragging. The default value for this option is false. (Since 2.61)
            autoPan 	        Boolean 	Auto-pan the map as you drag the marker near the edge. If the marker is draggable the default value for this option is true. (Since 2.87)
            zIndexProcess 	    Function 	This function is used for changing the z-Index order of the markers when they are overlaid on the map and is also called when their infowindow is opened. The default order is that the more southerly markers are placed higher than more northerly markers. This function is passed in the GMarker object and returns a number indicating the new z-index. (Since 2.98)
          
         GIcon
           Properties 	        Type 	        Description
           -------------------  ----------  -----------------------------------------------------------------------------------
            image 	            String 	        The foreground image URL of the icon.
            shadow 	            String 	        The shadow image URL of the icon.
            iconSize 	        GSize 	        The pixel size of the foreground image of the icon.
            shadowSize 	        GSize 	        The pixel size of the shadow image.
            iconAnchor 	        GPoint 	        The pixel coordinate relative to the top left corner of the icon image at which this icon is anchored to the map.
            infoWindowAnchor 	GPoint 	        The pixel coordinate relative to the top left corner of the icon image at which the info window is anchored to this icon.
            printImage 	        String 	        The URL of the foreground icon image used for printed maps. It must be the same size as the main icon image given by image.
            mozPrintImage 	    String 	        The URL of the foreground icon image used for printed maps in Firefox/Mozilla. It must be the same size as the main icon image given by image.
            printShadow 	    String 	        The URL of the shadow image used for printed maps. It should be a GIF image since most browsers cannot print PNG images.
            transparent 	    String 	        The URL of a virtually transparent version of the foreground icon image used to capture click events in Internet Explorer. This image should be a 24-bit PNG version of the main icon image with 1% opacity, but the same shape and size as the main icon.
            imageMap 	        Array of Number An array of integers representing the x/y coordinates of the image map we should use to specify the clickable part of the icon image in browsers other than Internet Explorer.
            maxHeight 	        Integer 	    Specifies the distance in pixels in which a marker will visually "rise" vertically when dragged. (Since 2.79)
            dragCrossImage 	    String 	        Specifies the cross image URL when an icon is dragged. (Since 2.79)
            dragCrossSize 	    GSize 	        Specifies the pixel size of the cross image when an icon is dragged. (Since 2.79)
            dragCrossAnchor 	GPoint 	        Specifies the pixel coordinate offsets (relative to the iconAnchor) of the cross image when an icon is dragged. (Since 2.79)
         
         */
    }
}
