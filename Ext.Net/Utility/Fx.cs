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
    public abstract partial class Fx : ExtObject
    {
        private FxConfig options;

        /// <summary>
        /// Fx config object
        /// </summary>
        public virtual FxConfig Options
        {
            get
            {
                return this.options;
            }
            set
            {
                this.options = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        [Description("")]
        public abstract string FxName
        { 
            get;
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Serialize()
        {
            return this.FxName.ConcatWith("(", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Arguments
        {
            get
            {
                if (this.Options == null)
                {
                    return "{}";
                }

                return new ClientConfig().Serialize(this.Options);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption("args", JsonMode.Raw)]
        [Description("")]
        protected internal string ArgumentsArray
        {
            get
            {
                return "[".ConcatWith(this.Arguments, "]");
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public static string AnchorConvert(AnchorPoint anchor)
        {
            switch (anchor)
            {
                case AnchorPoint.TopLeft:
                    return "tl";
                case AnchorPoint.Top:
                    return "t";
                case AnchorPoint.TopRight:
                    return "tr";
                case AnchorPoint.Left:
                    return "l";
                case AnchorPoint.Center:
                    return "c";
                case AnchorPoint.Right:
                    return "r";
                case AnchorPoint.BottomLeft:
                    return "bl";
                case AnchorPoint.Bottom:
                    return "b";
                case AnchorPoint.BottomRight:
                    return "br";
                default:
                    throw new ArgumentOutOfRangeException("anchor");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ElementFxConfig : ExtObject
    {
        private JFunction callback;

        /// <summary>
        /// A function called when the effect is finished. Note that effects are queued internally by the Fx class, so do not need to use the callback parameter to specify another effect -- effects can simply be chained together and called in sequence (e.g., el.slideIn().highlight();). The callback is intended for any additional code that should run once a particular effect has completed. The Element being operated upon is passed as the first parameter.
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue(null)]
        [Description("A function called when the effect is finished. Note that effects are queued internally by the Fx class, so do not need to use the callback parameter to specify another effect -- effects can simply be chained together and called in sequence (e.g., el.slideIn().highlight();). The callback is intended for any additional code that should run once a particular effect has completed. The Element being operated upon is passed as the first parameter.")]
        public JFunction Callback
        {
            get
            {
                return this.callback;
            }
            set
            {
                this.callback = value;
            }
        }

        private double duration = 0.0;

        /// <summary>
        /// The length of time (in seconds) that the effect should last
        /// </summary>
        [ConfigOption]
        [DefaultValue(0.0)]
        [Description("The length of time (in seconds) that the effect should last")]
        public double Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                this.duration = value;
            }
        }

        private Easing easing = Easing.EaseOut;

        /// <summary>
        /// A valid Easing value for the effect
        /// </summary>
        [ConfigOption(JsonMode.ToCamelLower)]
        [DefaultValue(Easing.EaseOut)]
        [Description("A valid Easing value for the effect")]
        public Easing Easing
        {
            get
            {
                return this.easing;
            }
            set
            {
                this.easing = value;
            }
        }

        private string scope = "this";

        /// <summary>
        /// The scope of the effect function
        /// </summary>
        [ConfigOption(JsonMode.Raw)]
        [DefaultValue("this")]
        [Description("The scope of the effect function")]
        public string Scope
        {
            get
            {
                return this.scope;
            }
            set
            {
                this.scope = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public virtual string Serialize()
        {
            return new ClientConfig().Serialize(this, true);
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FxConfig : ElementFxConfig
    {
        private string afterCls = "";

        /// <summary>
        /// A css class to apply after the effect
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("A css class to apply after the effect")]
        public string AfterCls
        {
            get
            {
                return this.afterCls;
            }
            set
            {
                this.afterCls = value;
            }
        }

        private string afterStyle = "";

        /// <summary>
        /// A style specification string, e.g. "width:100px", that will be applied to the Element after the effect finishes
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("A style specification string, e.g. 'width:100px', that will be applied to the Element after the effect finishes")]
        public string AfterStyle
        {
            get
            {
                return this.afterStyle;
            }
            set
            {
                this.afterStyle = value;
            }
        }

        private bool block = false;

        /// <summary>
        /// Whether the effect should block other effects from queueing while it runs
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether the effect should block other effects from queueing while it runs")]
        public bool Block
        {
            get
            {
                return this.block;
            }
            set
            {
                this.block = value;
            }
        }

        private bool concurrent = false;

        /// <summary>
        /// Whether to allow subsequently-queued effects to run at the same time as the current effect, or to ensure that they run in sequence
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to allow subsequently-queued effects to run at the same time as the current effect, or to ensure that they run in sequence")]
        public bool Concurrent
        {
            get
            {
                return this.concurrent;
            }
            set
            {
                this.concurrent = value;
            }
        }

        private bool remove = false;

        /// <summary>
        /// Whether the Element should be removed from the DOM and destroyed after the effect finishes
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        public bool Remove
        {
            get
            {
                return this.remove;
            }
            set
            {
                this.remove = value;
            }
        }

        private bool stopFx = false;

        /// <summary>
        /// Whether subsequent effects should be stopped and removed after the current effect finishes
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether subsequent effects should be stopped and removed after the current effect finishes")]
        public bool StopFx
        {
            get
            {
                return this.stopFx;
            }
            set
            {
                this.stopFx = value;
            }
        }

        private bool useDisplay = false;

        /// <summary>
        /// Whether to use the display CSS property instead of visibility when hiding Elements (only applies to effects that end with the element being visually hidden, ignored otherwise)
        /// </summary>
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to use the display CSS property instead of visibility when hiding Elements (only applies to effects that end with the element being visually hidden, ignored otherwise)")]
        public bool UseDisplay
        {
            get
            {
                return this.useDisplay;
            }
            set
            {
                this.useDisplay = value;
            }
        }
    }

    /// <summary>
    /// Fade an element in (from transparent to opaque). The ending opacity can be specified using the "endOpacity" config option. 
    /// </summary>
    [Description("Fade an element in (from transparent to opaque). The ending opacity can be specified using the 'endOpacity' config option. ")]
    public partial class FadeIn : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get 
            {
                return "fadeIn";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FadeInConfig : FxConfig
    {
        private float endOpacity = 1;

        /// <summary>
        /// The ending opacity
        /// </summary>
        [ConfigOption]
        [DefaultValue(1)]
        [Description("The ending opacity")]
        public float EndOpacity
        {
            get
            {
                return this.endOpacity;
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "EndOpacity must be between 0 and 1");
                }
                this.endOpacity = value;
            }
        }
    }

    /// <summary>
    /// Fade an element out (from opaque to transparent). The ending opacity can be specified using the "endOpacity" config option. Note that IE may require useDisplay:true in order to redisplay correctly. 
    /// </summary>
    [Description("Fade an element out (from opaque to transparent). The ending opacity can be specified using the 'endOpacit' config option. Note that IE may require useDisplay:true in order to redisplay correctly. ")]
    public partial class FadeOut : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "fadeOut";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class FadeOutConfig : FxConfig
    {
        private float endOpacity = 0;

        /// <summary>
        /// The ending opacity
        /// </summary>
        [ConfigOption]
        [DefaultValue(0)]
        [Description("The ending opacity")]
        public float EndOpacity
        {
            get
            {
                return this.endOpacity;
            }
            set
            {
                if (value < 0 || value > 1)
                {
                    throw new ArgumentOutOfRangeException("value", "EndOpacity must be between 0 and 1");
                }
                this.endOpacity = value;
            }
        }
    }

    /// <summary>
    /// Shows a ripple of exploding, attenuating borders to draw attention to an Element
    /// </summary>
    [Description("Shows a ripple of exploding, attenuating borders to draw attention to an Element")]
    public partial class Frame : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "frame";
            }
        }

        private string color = "C3DAF9";

        /// <summary>
        /// The color of the border. Should be a 6 char hex color without the leading # (defaults to light blue: 'C3DAF9').
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

        private int count = 1;

        /// <summary>
        /// The number of ripples to display (defaults to 1)
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                this.count = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Serialize()
        {
            return this.FxName.ConcatWith("(", JSON.Serialize(this.Color), ",", this.Count, ",", this.Options != null ? new ClientConfig().Serialize(this.Options):"{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Arguments
        {
            get
            {
                return JSON.Serialize(this.Color).ConcatWith(",", this.Count, ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}");
            }
        }
    }

    /// <summary>
    /// Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect. 
    /// </summary>
    [Description("Slides the element while fading it out of view. An anchor point can be optionally passed to set the ending point of the effect. ")]
    public partial class Ghost : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "ghost";
            }
        }

        private AnchorPoint anchor = AnchorPoint.Bottom;

        /// <summary>
        /// One of the valid Fx anchor positions (defaults to AnchorPoint.CenterBottom)
        /// </summary>
        public AnchorPoint Anchor
        {
            get
            {
                return this.anchor;
            }
            set
            {
                this.anchor = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Serialize()
        {
            return this.FxName.ConcatWith("(", JSON.Serialize(Fx.AnchorConvert(this.Anchor)), ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Arguments
        {
            get
            {
                return JSON.Serialize(Fx.AnchorConvert(this.Anchor)).ConcatWith(",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}");
            }
        }
    }

    /// <summary>
    /// Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the "attr" config option) and then fading back to the original color. If no original color is available, you should provide the "endColor" config option which will be cleared after the animation. 
    /// </summary>
    [Description("Highlights the Element by setting a color (applies to the background-color by default, but can be changed using the 'attr' config option) and then fading back to the original color. If no original color is available, you should provide the 'endColor' config option which will be cleared after the animation. ")]
    public partial class Highlight : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "highlight";
            }
        }

        private string color = "ffff9c";

        /// <summary>
        /// The highlight color. Should be a 6 char hex color without the leading # (defaults to yellow: 'ffff9c')
        /// </summary>
        public string Color
        {
            get
            {
                return this.color;
            }
            set
            {
                this.color = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Serialize()
        {
            return this.FxName.ConcatWith("(", JSON.Serialize(this.Color), ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Arguments
        {
            get
            {
                return JSON.Serialize(this.Color).ConcatWith(",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}");
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class HighlightConfig : FxConfig
    {
        private string attr = "background-color";

        /// <summary>
        /// Can be any valid CSS property (attribute) that supports a color value
        /// </summary>
        [ConfigOption]
        [DefaultValue("background-color")]
        [Description("Can be any valid CSS property (attribute) that supports a color value")]
        public string Attr
        {
            get
            {
                return this.attr;
            }
            set
            {
                this.attr = value;
            }
        }

        private string endColor = "";

        /// <summary>
        /// End fading color
        /// </summary>
        [ConfigOption]
        [DefaultValue("")]
        [Description("End fading color")]
        public string EndColor
        {
            get
            {
                return this.endColor;
            }
            set
            {
                this.endColor = value;
            }
        }
    }

    /// <summary>
    /// Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. 
    /// </summary>
    [Description("Fades the element out while slowly expanding it in all directions. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. ")]
    public partial class Puff : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "puff";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class Scale : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "scale";
            }
        }

        private int? width;

        /// <summary>
        /// The new width (pass undefined to keep the original width)
        /// </summary>
        public int? Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        private int? height;

        /// <summary>
        /// The new height (pass undefined to keep the original height)
        /// </summary>
        public int? Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Serialize()
        {
            return this.FxName.ConcatWith("(", JSON.Serialize(this.Width), ",", JSON.Serialize(this.Height), ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Arguments
        {
            get
            {
                return JSON.Serialize(this.Width).ConcatWith(",", JSON.Serialize(this.Height), ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}");
            }
        }
    }

    /// <summary>
    /// Animates the transition of any combination of an element's dimensions, xy position and/or opacity. Any of these properties not specified in the config object will not be changed. This effect requires that at least one new dimension, position or opacity setting must be passed in on the config object in order for the function to have any effect. 
    /// </summary>
    [Description("Animates the transition of any combination of an element's dimensions, xy position and/or opacity. Any of these properties not specified in the config object will not be changed. This effect requires that at least one new dimension, position or opacity setting must be passed in on the config object in order for the function to have any effect. ")]
    public partial class Shift : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "shift";
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Description("")]
    public partial class ShiftConfig : FxConfig
    {
        private int? width;

        /// <summary>
        /// Element's width
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Element's width")]
        public int? Width
        {
            get
            {
                return this.width;
            }
            set
            {
                this.width = value;
            }
        }

        private int? height;

        /// <summary>
        /// Element's height
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Element's height")]
        public int? Height
        {
            get
            {
                return this.height;
            }
            set
            {
                this.height = value;
            }
        }

        private int? x;

        /// <summary>
        /// Element's x position
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Element's x position")]
        public int? X
        {
            get
            {
                return this.x;
            }
            set
            {
                this.x = value;
            }
        }

        private int? y;

        /// <summary>
        /// Element's y position
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Element's y position")]
        public int? Y
        {
            get
            {
                return this.y;
            }
            set
            {
                this.y = value;
            }
        }

        private float? opacity;

        /// <summary>
        /// Element's opacity
        /// </summary>
        [ConfigOption]
        [DefaultValue(null)]
        [Description("Element's opacity")]
        public float? Opacity
        {
            get
            {
                return this.opacity;
            }
            set
            {
                this.opacity = value;
            }
        }
    }

    /// <summary>
    /// Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. 
    /// </summary>
    [Description("Slides the element into view. An anchor point can be optionally passed to set the point of origin for the slide effect. This function automatically handles wrapping the element with a fixed-size container if needed. ")]
    public partial class SlideIn : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "slideIn";
            }
        }

        private AnchorPoint anchor = AnchorPoint.Top;

        /// <summary>
        /// One of the valid Fx anchor positions (defaults to AnchorPoint.CenterTop)
        /// </summary>
        public AnchorPoint Anchor
        {
            get
            {
                return this.anchor;
            }
            set
            {
                this.anchor = value;
            }
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Serialize()
        {
            return this.FxName.ConcatWith("(", JSON.Serialize(Fx.AnchorConvert(this.Anchor)), ",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}", ")");
        }

		/// <summary>
		/// 
		/// </summary>
		[Description("")]
        public override string Arguments
        {
            get
            {
                return JSON.Serialize(Fx.AnchorConvert(this.Anchor)).ConcatWith(",", this.Options != null ? new ClientConfig().Serialize(this.Options) : "{}");
            }
        }
    }

    /// <summary>
    /// Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.
    /// </summary>
    [Description("Slides the element out of view. An anchor point can be optionally passed to set the end point for the slide effect. When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired. This function automatically handles wrapping the element with a fixed-size container if needed.")]
    public partial class SlideOut : SlideIn
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "slideOut";
            }
        }
    }

    /// <summary>
    /// Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.
    /// </summary>
    [Description("Blinks the element as if it was clicked and then collapses on its center (similar to switching off a television). When the effect is completed, the element will be hidden (visibility = 'hidden') but block elements will still take up space in the document. The element must be removed from the DOM using the 'remove' config option if desired.")]
    public partial class SwitchOff : Fx
    {
		/// <summary>
		/// 
		/// </summary>
        [ConfigOption]
		[Description("")]
        public override string FxName
        {
            get
            {
                return "switchOff";
            }
        }
    }
}