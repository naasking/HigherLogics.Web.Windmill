﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// The size of buttons.
    /// </summary>
    public enum ButtonSize
    {
        Regular,
        Small,
        Large,
        Larger,
    }

    /// <summary>
    /// Flags a button as part of an input group.
    /// </summary>
    public enum InputGroup
    {
        /// <summary>
        /// Button is not part of an input group.
        /// </summary>
        None,
        /// <summary>
        /// Button is on the left side of an input group.
        /// </summary>
        Left,
        /// <summary>
        /// Button is on the right side of an input group.
        /// </summary>
        Right,
    }

    public class WindmillButtonTagHelper : WindmillTagHelper
    {
        public WindmillButtonTagHelper() : base("")
        {
        }

        /// <summary>
        /// True if the button is to show as disabled.
        /// </summary>
        public bool Disabled { get; set; }

        /// <summary>
        /// The button size.
        /// </summary>
        public ButtonSize Size { get; set; }

        /// <summary>
        /// Change the stying if this button belongs to an input group.
        /// </summary>
        public InputGroup InputGroup { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            // From Windmill docs:
            // For disabled buttons ADD these classes: opacity-50 cursor-not-allowed
            // And REMOVE these classes: active:bg-purple-600 hover:bg-purple-700 focus:shadow-outline-purple
            BaseStyles = $"font-medium leading-5 transition-colors border border-transparent duration-150 focus:outline-none{(Disabled?" cursor-not-allowed opacity-50": " active:bg-purple-600 hover:bg-purple-700 focus:shadow-outline-purple")}{GetSizeClasses()}";
            base.Process(context, output);
        }

        string GetSizeClasses()
        {
            switch (Size)
            {
                case ButtonSize.Regular when InputGroup == InputGroup.None:
                    return " px-4 py-2 text-sm rounded-lg";
                case ButtonSize.Regular when InputGroup == InputGroup.Left:
                    return " px-4 py-2 text-sm rounded-l-lg absolute inset-y-0";
                case ButtonSize.Regular when InputGroup == InputGroup.Right:
                    return " px-4 py-2 text-sm rounded-r-lg absolute inset-y-0 right-0";
                case ButtonSize.Small when InputGroup == InputGroup.None:
                    return " px-3 py-1 text-sm rounded-md";
                case ButtonSize.Small when InputGroup == InputGroup.Left:
                    return " px-3 py-1 text-sm rounded-l-md absolute inset-y-0";
                case ButtonSize.Small when InputGroup == InputGroup.Right:
                    return " px-3 py-1 text-sm rounded-r-md absolute inset-y-0 right-0";
                case ButtonSize.Large when InputGroup == InputGroup.None:
                    return " px-5 py-3 rounded-lg";
                case ButtonSize.Large when InputGroup == InputGroup.Left:
                    return " px-5 py-3 rounded-l-lg absolute inset-y-0";
                case ButtonSize.Large when InputGroup == InputGroup.Right:
                    return " px-5 py-3 rounded-r-lg absolute inset-y-0 right-0";
                case ButtonSize.Larger when InputGroup == InputGroup.None:
                    return " px-10 py-4 rounded-lg";
                case ButtonSize.Larger when InputGroup == InputGroup.Left:
                    return " px-10 py-4 rounded-l-lg absolute inset-y-0";
                case ButtonSize.Larger when InputGroup == InputGroup.Right:
                    return " px-10 py-4 rounded-r-lg absolute inset-y-0 right-0";
                default:
                    throw new NotSupportedException($"Unrecognized ButtonSize: {Size}");
            }
        }
    }
}