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
using System.Drawing;
using System.Web.UI;
using System.Collections.Generic;

namespace Ext.Net
{
    /// <summary>
    /// This is a multi-pane, application-oriented UI layout style that supports multiple nested panels, automatic split bars between regions and built-in expanding and collapsing of regions.
    /// </summary>
    [Meta]
    [ParseChildren(true)]
    [ToolboxData("<{0}:BorderLayout runat=\"server\"><West Split=\"true\" Collapsible=\"true\"><{0}:Panel runat=\"server\" Title=\"West\" Width=\"175\" /></West><Center><{0}:Panel runat=\"server\" Title=\"Center\" /></Center><East Split=\"true\" Collapsible=\"true\"><{0}:Panel runat=\"server\" Title=\"East\" Width=\"175\" /></East><South Split=\"true\" Collapsible=\"true\"><{0}:Panel runat=\"server\" Title=\"South\" Height=\"150\" /></South></{0}:BorderLayout>")]
    [ToolboxBitmap(typeof(BorderLayout), "Build.ToolboxIcons.Layout.bmp")]
    [Designer(typeof(BorderLayoutDesigner))]
    [Description("This is a multi-pane, application-oriented UI layout style that supports multiple nested panels, automatic split bars between regions and built-in expanding and collapsing of regions.")]
    public partial class BorderLayout : ContainerLayout
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("")]
        public BorderLayout() { }

        /// <summary>
        /// 
        /// </summary>
        [Category("4. Layout")]
        [Description("")]
        public override string LayoutType
        {
            get
            {
                return "border";
            }
        }
        
        private BorderLayoutRegion north;
        private BorderLayoutRegion south;
        private BorderLayoutRegion west;
        private BorderLayoutRegion east;
        private BorderLayoutRegion center;

        /// <summary>
        /// Represent options of north region
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [Description("Represent options of north region")]
        public BorderLayoutRegion North
        {
            get
            {
                if (this.north == null)
                {
                    this.north = new BorderLayoutRegion(this, RegionPosition.North);

                    if (this.IsTrackingViewState)
                    {
                        this.north.TrackViewState();
                    }
                }

                return this.north;
            }
        }

        /// <summary>
        /// Represent options of south region
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [Description("Represent options of south region")]
        public BorderLayoutRegion South
        {
            get
            {
                if (this.south == null)
                {
                    this.south = new BorderLayoutRegion(this, RegionPosition.South);

                    if (this.IsTrackingViewState)
                    {
                        this.south.TrackViewState();
                    }
                }

                return this.south;
            }
        }

        /// <summary>
        /// Represent options of west region
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [Description("Represent options of west region")]
        public BorderLayoutRegion West
        {
            get
            {
                if (this.west == null)
                {
                    this.west = new BorderLayoutRegion(this, RegionPosition.West);

                    if (this.IsTrackingViewState)
                    {
                        this.west.TrackViewState();
                    }
                }

                return this.west;
            }
        }

        /// <summary>
        /// Represent options of east region
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [Description("Represent options of east region")]
        public BorderLayoutRegion East
        {
            get
            {
                if (this.east == null)
                {
                    this.east = new BorderLayoutRegion(this, RegionPosition.East);

                    if (this.IsTrackingViewState)
                    {
                        this.east.TrackViewState();
                    }
                }

                return this.east;
            }
        }

        /// <summary>
        /// Represent options of center region
        /// </summary>
        [Meta]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        [ViewStateMember]
        [Description("Represent options of center region")]
        public BorderLayoutRegion Center
        {
            get
            {
                if (this.center == null)
                {
                    this.center = new BorderLayoutRegion(this, RegionPosition.Center);

                    if (this.IsTrackingViewState)
                    {
                        this.center.TrackViewState();
                    }
                }

                return this.center;
            }
        }

        List<BorderLayoutRegion> regions = null;

        internal List<BorderLayoutRegion> Regions
        {
            get
            {
                if (this.regions != null)
                {
                    return this.regions;
                }

                this.regions = new List<BorderLayoutRegion>();
                this.regions.AddRange(new BorderLayoutRegion[] {
                        this.North, 
                        this.East,
                        this.South,
                        this.West,
                        this.Center
                });
                
                return this.regions;
            }
        }

        internal void ResetRegion(RegionPosition region)
        {
            switch (region)
            {
                case RegionPosition.North:
                    this.north = null;
                    break;
                case RegionPosition.South:
                    this.south = null;
                    break;
                case RegionPosition.East:
                    this.east = null;
                    break;
                case RegionPosition.West:
                    this.west = null;
                    break;
                case RegionPosition.Center:
                    this.center = null;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("region");
            }
        }
    }
}