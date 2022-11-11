using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// A table pager using buttons.
    /// </summary>
    public class WindmillButtonPagerTagHelper : WindmillAbstractPagerTagHelper
    {
        public WindmillButtonPagerTagHelper() : base()
        {
        }

        public string? Name { get; set; }

        protected override void WritePagingItem(int page, TagHelperOutput output, string? ariaLabel = null, string? content = null)
        {
            output.Content.AppendHtml($@"<li><button name=""{Name}"" class=""");
            if (page == CurrentPage)
                output.Content.AppendHtml(@"px-3 py-1 text-white transition-colors duration-150 bg-purple-600 border border-r-0 border-purple-600 rounded-md focus:outline-none focus:shadow-outline-purple""");
            else
                output.Content.AppendHtml(@"px-3 py-1 rounded-md focus:outline-none focus:shadow-outline-purple""");
            if (!string.IsNullOrEmpty(ariaLabel))
                output.Content.AppendHtml(" aria-label=\"").AppendHtml(ariaLabel).AppendHtml("\"");
            output.Content.AppendHtml($@" value=""{page}"">");
            output.Content.AppendHtml(string.IsNullOrEmpty(content) ? page.ToString() : content);
            output.Content.AppendHtmlLine("</button></li>");
        }
    }
}
