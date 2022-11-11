using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;
using System.Drawing;

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
    /// The button type that specifies its colouring.
    /// </summary>
    public enum ButtonKind
    {
        /// <summary>
        /// Primary colours.
        /// </summary>
        Primary,
        /// <summary>
        /// Secondary colours.
        /// </summary>
        Secondary,

        /// <summary>
        /// Danger colours.
        /// </summary>
        Danger,

        //FIXME: maybe add warning or danger?
    }

    /// <summary>
    /// A button element.
    /// </summary>
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
        public GroupLayout Layout { get; set; }

        /// <summary>
        /// The kind of button to render.
        /// </summary>
        public ButtonKind Kind { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            // From Windmill docs:
            // For disabled buttons ADD these classes: opacity-50 cursor-not-allowed
            // And REMOVE these classes: active:bg-purple-600 hover:bg-purple-700 focus:shadow-outline-purple
            BaseStyles = "font-medium leading-5 transition-colors duration-150 focus:outline-none border " + GetColours() + GetSizeClasses();
            base.Process(context, output);
        }

        string GetColours()
        {
            switch (Kind)
            {
                case ButtonKind.Primary when Disabled:
                    return "text-white bg-purple-600 cursor-not-allowed opacity-50 border-transparent";
                case ButtonKind.Primary when !Disabled:
                    return "text-white bg-purple-600 active:bg-purple-600 hover:bg-purple-700 focus:shadow-outline-purple border-transparent";
                case ButtonKind.Secondary when Disabled:
                    return "text-gray-700 border-gray-300 dark:text-gray-400 active:bg-transparent hover:border-gray-500 focus:border-gray-500 active:text-gray-500 focus:outline-none focus:shadow-outline-gray text-white bg-purple-600 cursor-not-allowed opacity-50 border-gray-300";
                case ButtonKind.Secondary when !Disabled:
                    return "text-gray-700 border-gray-300 dark:text-gray-400 active:bg-transparent hover:border-gray-500 focus:border-gray-500 active:text-gray-500 focus:outline-none focus:shadow-outline-gray border-gray-300";
                case ButtonKind.Danger when Disabled:
                    return "text-white bg-red-600 cursor-not-allowed opacity-50 border-transparent";
                case ButtonKind.Danger when !Disabled:
                    return "text-white bg-red-600 active:bg-red-600 hover:bg-red-700 focus:shadow-outline-red border-transparent";
                default:
                    throw new NotSupportedException($"Unrecognized button kind: {Kind}");
            }
        }

        string GetSizeClasses()
        {
            switch (Size)
            {
                case ButtonSize.Regular when Layout == GroupLayout.None:
                    return " px-4 py-2 text-sm rounded-lg";
                case ButtonSize.Regular when Layout == GroupLayout.Left:
                    return " px-4 py-2 text-sm rounded-l-lg absolute inset-y-0";
                case ButtonSize.Regular when Layout == GroupLayout.Right:
                    return " px-4 py-2 text-sm rounded-r-lg absolute inset-y-0 right-0";
                case ButtonSize.Small when Layout == GroupLayout.None:
                    return " px-3 py-1 text-sm rounded-md";
                case ButtonSize.Small when Layout == GroupLayout.Left:
                    return " px-3 py-1 text-sm rounded-l-md absolute inset-y-0";
                case ButtonSize.Small when Layout == GroupLayout.Right:
                    return " px-3 py-1 text-sm rounded-r-md absolute inset-y-0 right-0";
                case ButtonSize.Large when Layout == GroupLayout.None:
                    return " px-5 py-3 rounded-lg";
                case ButtonSize.Large when Layout == GroupLayout.Left:
                    return " px-5 py-3 rounded-l-lg absolute inset-y-0";
                case ButtonSize.Large when Layout == GroupLayout.Right:
                    return " px-5 py-3 rounded-r-lg absolute inset-y-0 right-0";
                case ButtonSize.Larger when Layout == GroupLayout.None:
                    return " px-10 py-4 rounded-lg";
                case ButtonSize.Larger when Layout == GroupLayout.Left:
                    return " px-10 py-4 rounded-l-lg absolute inset-y-0";
                case ButtonSize.Larger when Layout == GroupLayout.Right:
                    return " px-10 py-4 rounded-r-lg absolute inset-y-0 right-0";
                default:
                    throw new NotSupportedException($"Unrecognized ButtonSize: {Size}");
            }
        }
    }
}