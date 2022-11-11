﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigherLogics.Web.Windmill
{
    public enum PagerType { Button, Link, }

    /// <summary>
    /// A table pager.
    /// </summary>
    public class WindmillPagerTagHelper : WindmillTagHelper
    {
        public WindmillPagerTagHelper() : base("grid text-xs font-semibold tracking-wide text-gray-500 uppercase border-t dark:border-gray-700 bg-gray-50 sm:grid-cols-9 dark:text-gray-400 dark:bg-gray-800")
        {
        }

        public int ItemCount { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }
        public PagerType Type { get; set; }
        /// <summary>
        /// Generate a link for the given page.
        /// </summary>
        public Func<int, string>? GetLink { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);

            var itemsStart = 1 + CurrentPage * ItemsPerPage;
            var itemsEnd = ItemsPerPage == 0 ? 1 : (1 + CurrentPage) * ItemCount / ItemsPerPage + ItemCount % ItemsPerPage;

            output.PreContent.AppendHtml($@"<span class=""flex items-center col-span-3"">Showing {itemsStart}-{itemsEnd} of {ItemCount}</span>
<span class=""col-span-2""></span>
<span class=""flex col-span-4 mt-2 sm:mt-auto sm:justify-end"">
    <nav aria-label=""Table navigation""><ul class=""inline-flex items-center"">");

            output.PostContent.AppendHtml($@"</ul></nav></span>");
        }
    }
}
