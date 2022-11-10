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
    /// A menu that appears in the action header.
    /// </summary>
    public class WindmillActionMenuLinkTagHelper : WindmillTagHelper
    {
        public WindmillActionMenuLinkTagHelper() : base("flex")
        {
        }

        /// <summary>
        /// The link for the menu item, if any.
        /// </summary>
        public string? Href { get; set; }

        /// <summary>
        /// Any extra context for the content.
        /// </summary>
        /// <remarks>
        /// Extra content might be the number of unread messages, which you would want to show alongside the menu item name.
        /// </remarks>
        public string? Extra { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            base.Process(context, output);
            output.Attributes.AddDefault("href", Href ?? "#");
            output.RemoveAttribute("class", out var css);

            // wrap content in a link
            var justify = Extra != null ? " justify-between" : "";
            output.PreContent.AppendHtml($@"<a class=""inline-flex items-center{justify} w-full px-2 py-1 text-sm font-semibold transition-colors duration-150 rounded-md hover:bg-gray-100 hover:text-gray-800 dark:hover:bg-gray-800 dark:hover:text-gray-200""");
            foreach (var attr in output.Attributes)
                attr.CopyTo(output.PreContent);
            output.PreContent.AppendHtml(">");
            output.Attributes.Clear();
            output.Attributes.Add(css);

            if (Extra != null)
            {
                output.PostContent.AppendHtmlLine(
                    $@"<span class=""inline-flex items-center justify-center px-2 py-1 text-xs font-bold leading-none text-red-600 bg-red-100 rounded-full dark:text-red-100 dark:bg-red-600"">{Extra}</span>");
            }
            output.PostContent.AppendHtmlLine("</a>");
        }
    }
}
