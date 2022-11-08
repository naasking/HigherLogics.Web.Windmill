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
    public class WindmillSidebarMenuListTagHelper : WindmillTagHelper
    {
        public WindmillSidebarMenuListTagHelper() : base("")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "template";
            output.Attributes.Add("x-if", "isPagesMenuOpen");
            base.Process(context, output);

            output.PreContent.AppendHtmlLine(@"<ul
    x-transition:enter=""transition-all ease-in-out duration-300""
    x-transition:enter-start=""opacity-25 max-h-0""
    x-transition:enter-end=""opacity-100 max-h-xl""
    x-transition:leave=""transition-all ease-in-out duration-300""
    x-transition:leave-start=""opacity-100 max-h-xl""
    x-transition:leave-end=""opacity-0 max-h-0""
    class=""p-2 mt-2 space-y-2 overflow-hidden text-sm font-medium text-gray-500 rounded-md shadow-inner bg-gray-50 dark:text-gray-400 dark:bg-gray-900""
    aria-label=""submenu"">");

            output.PostContent.AppendHtmlLine("</ul>");
        }
    }
}
