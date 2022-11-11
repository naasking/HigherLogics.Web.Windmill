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
    /// A table pager.
    /// </summary>
    public abstract class WindmillAbstractPagerTagHelper : WindmillTagHelper
    {
        public WindmillAbstractPagerTagHelper() : base("grid text-xs font-semibold tracking-wide text-gray-500 uppercase border-t dark:border-gray-700 bg-gray-50 sm:grid-cols-9 dark:text-gray-400 dark:bg-gray-800")
        {
        }

        public int ItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);

            var pageCount = ItemCount / ItemsPerPage + ItemCount % ItemsPerPage;
            var itemsEnd = CurrentPage * ItemsPerPage;
            var itemsStart = itemsEnd - ItemsPerPage + 1;

            output.Content.Reinitialize();
            output.Content.AppendHtml($@"<span class=""flex items-center col-span-3"">Showing {itemsStart}-{itemsEnd} of {ItemCount}</span>
<span class=""col-span-2""></span>
<span class=""flex col-span-4 mt-2 sm:mt-auto sm:justify-end"">
    <nav aria-label=""Table navigation""><ul class=""inline-flex items-center"">");

            // previous item
            if (CurrentPage > 1)
            {
                WritePagingItem(CurrentPage - 1, output, ariaLabel: "Previous", content:
    @"<svg class=""w-4 h-4 fill-current"" aria-hidden=""true"" viewBox=""0 0 20 20"">
<path d=""M12.707 5.293a1 1 0 010 1.414L9.414 10l3.293 3.293a1 1 0 01-1.414 1.414l-4-4a1 1 0 010-1.414l4-4a1 1 0 011.414 0z""
    clip-rule=""evenodd"" fill-rule=""evenodd""></path>
</svg>
");
            }
            // Pager carries ~9 slots before it exceeds 640px width. When page count exceeds 9,
            // it falls into one of the following modes:
            // 1. current page is in the first 4 items: < 1 2 3 4 ... 8 9 >
            // 2. current page is in the middle: < ... 4 5 6 7 8 ... >
            // 3. current page is in the last 4 items: < 1 2 ... 6 7 8 9 >
            if (pageCount < 9)
            {
                for (int i = 1; i < pageCount; ++i)
                {
                    WritePagingItem(i, output);
                }
            }
            else if (CurrentPage < 5)
            {
                for (int i = 1; i < 5; ++i)
                {
                    WritePagingItem(i, output);
                }
                output.Content.AppendHtmlLine(@"<li><span class=""px-3 py-1"">...</span></li>");
                WritePagingItem(pageCount - 2, output);
                WritePagingItem(pageCount - 1, output);
            }
            else if (CurrentPage > pageCount - 5)
            {
                WritePagingItem(1, output);
                WritePagingItem(2, output);
                output.Content.AppendHtmlLine(@"<li><span class=""px-3 py-1"">...</span></li>");
                for (int i = pageCount - 4; i < pageCount; ++i)
                {
                    WritePagingItem(i, output);
                }
            }
            else
            {
                output.Content.AppendHtmlLine(@"<li><span class=""px-3 py-1"">...</span></li>");
                for (int i = CurrentPage - 2; i <= CurrentPage + 2; ++i)
                {
                    WritePagingItem(i, output);
                }
                output.Content.AppendHtmlLine(@"<li><span class=""px-3 py-1"">...</span></li>");
            }

            // next item
            if (CurrentPage < pageCount - 1)
            {
                WritePagingItem(CurrentPage + 1, output, ariaLabel: "Next", content:
    @"<svg class=""w-4 h-4 fill-current"" aria-hidden=""true"" viewBox=""0 0 20 20"">
<path d=""M7.293 14.707a1 1 0 010-1.414L10.586 10 7.293 6.707a1 1 0 011.414-1.414l4 4a1 1 0 010 1.414l-4 4a1 1 0 01-1.414 0z""
    clip-rule=""evenodd"" fill-rule=""evenodd""></path>
</svg>
");
            }
            output.Content.AppendHtml($@"</ul></nav></span>");
        }

        protected abstract void WritePagingItem(int page, TagHelperOutput output, string? ariaLabel = null, string? content = null);
    }
}
