using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// A card. The padding and shadow are left unset.
    /// </summary>
    public class WindmillTableActionTagHelper : WindmillTagHelper
    {
        public WindmillTableActionTagHelper() : base("flex items-center justify-between px-2 py-2 text-sm font-medium leading-5 rounded-lg focus:outline-none focus:shadow-outline-gray")
        {
        }
        public string? Tag { get; set; }
        public ButtonKind Kind { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = Tag ?? "button";
            BaseStyles += " " + GetColour();
            base.Process(context, output);
        }

        string GetColour()
        {
            switch (Kind)
            {
                case ButtonKind.Primary:
                    return "text-purple-600 dark:text-gray-400";
                case ButtonKind.Secondary:
                    return "text-purple-600";
                case ButtonKind.Danger:
                    return "text-red-600 dark:text-red-400";
                default:
                    throw new NotSupportedException($"Unrecognized action kind: {Kind}");
            }
        }
    }
}
