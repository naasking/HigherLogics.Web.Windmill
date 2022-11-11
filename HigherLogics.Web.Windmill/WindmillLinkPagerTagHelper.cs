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
    /// A table pager using links.
    /// </summary>
    public class WindmillLinkPagerTagHelper : WindmillAbstractPagerTagHelper
    {
        public WindmillLinkPagerTagHelper() : base()
        {
        }

        /// <summary>
        /// Function used to generate paging links.
        /// </summary>
        public Func<int, string>? GetLink { get; set; }

        protected override void WritePagingItem(int page, TagHelperOutput output, string? ariaLabel = null, string? content = null)
        {
            output.Content.AppendHtml($@"<li><a href=""").AppendHtml(GetLink?.Invoke(page)).AppendHtml(@""" class=""");
            if (page == CurrentPage)
                output.Content.AppendHtml(@"px-3 py-1 text-white transition-colors duration-150 bg-purple-600 border border-r-0 border-purple-600 rounded-md focus:outline-none focus:shadow-outline-purple""");
            else
                output.Content.AppendHtml(@"px-3 py-1 rounded-md focus:outline-none focus:shadow-outline-purple""");
            if (!string.IsNullOrEmpty(ariaLabel))
                output.Content.AppendHtml(" aria-label=\"").AppendHtml(ariaLabel).AppendHtml("\"");
            output.Content.AppendHtml(">");
            output.Content.AppendHtml(string.IsNullOrEmpty(content) ? page.ToString() : content);
            output.Content.AppendHtmlLine("</a></li>");
        }
    }
}
