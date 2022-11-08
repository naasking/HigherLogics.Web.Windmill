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
    /// A normal link item in the sidebar.
    /// </summary>
    public class WindmillSidebarLinkTagHelper : WindmillTagHelper
    {
        public WindmillSidebarLinkTagHelper() : base("relative px-6 py-3")
        {
        }

        /// <summary>
        /// True if the item is currently active.
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// The URL
        /// </summary>
        public string? Href { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            base.Process(context, output);

            if (Active)
            {
                output.PreContent
                    .AppendHtmlLine(@"<span class=""absolute inset-y-0 left-0 w-1 bg-purple-600 rounded-tr-lg rounded-br-lg"" aria-hidden=""true""></span>")
                    .AppendHtmlLine($@"<a class=""inline-flex items-center w-full text-sm font-semibold text-gray-800 transition-colors duration-150 hover:text-gray-800 dark:hover:text-gray-200 dark:text-gray-100"" href=""{Href ?? ""}"">");
            }
            else
            {
                output.PreContent.AppendHtmlLine(
                    $@"<a class=""inline-flex items-center w-full text-sm font-semibold transition-colors duration-150 hover:text-gray-800 dark:hover:text-gray-200"" href=""{Href ?? ""}"">");
            }

            output.PostContent.AppendHtml("</a>");
        }
    }
}
