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
    /// A link for a sidebar menu.
    /// </summary>
    public class WindmillSidebarMenuLinkTagHelper : WindmillTagHelper
    {
        public WindmillSidebarMenuLinkTagHelper() : base("px-2 py-1 transition-colors duration-150 hover:text-gray-800 dark:hover:text-gray-200")
        {
        }

        /// <summary>
        /// Whether the element is active.
        /// </summary>
        public bool Active { get; set; }
        
        /// <summary>
        /// The link.
        /// </summary>
        public string? Href { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            base.Process(context, output);

            if (Active)
                output.PreContent
                    .AppendHtmlLine(@"<span class=""absolute inset-y-0 left-0 w-1 bg-purple-600 rounded-tr-lg rounded-br-lg"" aria-hidden=""true""></span>")
                    .AppendHtml($@"<a class=""w-full"" href=""{Href ?? ""}"">");
            else
                output.PreContent.AppendHtml($@"<a class=""w-full text-gray-800 dark:text-gray-100"" href=""{Href ?? ""}"">");

            output.PostContent.AppendHtmlLine("</a>");
        }
    }
}
