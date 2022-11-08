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
    public class WindmillPagerTagHelper : WindmillTagHelper
    {
        public WindmillPagerTagHelper() : base("grid px-4 py-3 text-xs font-semibold tracking-wide text-gray-500 uppercase border-t dark:border-gray-700 bg-gray-50 sm:grid-cols-9 dark:text-gray-400 dark:bg-gray-800")
        {
        }

        public int ItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int PageIndex { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);

            var itemsStart = 1 + PageIndex * ItemsPerPage;
            var itemsEnd = ItemCount / ItemsPerPage + ItemCount % ItemsPerPage;
            output.PreContent.AppendHtml($@"<span class=""flex items-center col-span-3"">Showing {itemsStart}-{itemsEnd} of {ItemCount}</span>
<span class=""col-span-2""></span>
<span class=""flex col-span-4 mt-2 sm:mt-auto sm:justify-end"">
    <nav aria-label=""Table navigation"">");

            output.PostContent.AppendHtml($@"</nav></span>");
        }
    }
}
