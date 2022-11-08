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
    /// A tag helper for constructing a sidebar.
    /// </summary>
    public class WindmillSidebarTagHelper : WindmillTagHelper
    {
        public WindmillSidebarTagHelper() : base("")
        {
            Name = "";
        }

        /// <summary>
        /// The name that shows at the top of the sidebar.
        /// </summary>
        public string Name { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            //output.TagName = "aside";
            //base.Process(context, output);

            // The sidebar is rendered twice, once for desktop and once for mobile. The mobile
            // version is basically just hidden by default and expanded by Alpine on demand
            var content = ToString(output.GetChildContentAsync().Result, HtmlEncoder.Default);

            base.Process(context, output);

            var attr = output.Attributes;
            string classes;
            if (attr.TryGetAttribute("class", out var css))
            {
                attr.Remove(css);
                classes = ToString(css.Value, HtmlEncoder.Default);
            }
            else
            {
                classes = "";
            }
            output.Content.Clear();

            // write desktop menu
            WrapContent(content, attr, output, classes, "z-20 hidden w-64 overflow-y-auto bg-white dark:bg-gray-800 md:block flex-shrink-0");

            // write mobile menu
            output.Content.AppendHtml($@"<div x-show=""isSideMenuOpen""
x-transition:enter=""transition ease-in-out duration-150""
x-transition:enter-start=""opacity-0""
x-transition:enter-end=""opacity-100""
x-transition:leave=""transition ease-in-out duration-150""
x-transition:leave-start=""opacity-100""
x-transition:leave-end=""opacity-0""
class=""fixed inset-0 z-10 flex items-end bg-black bg-opacity-50 sm:items-center sm:justify-center""></div>");

            attr.Add("x-show", "isSideMenuOpen");
            attr.Add("x-transition:enter", "transition ease-in-out duration-150");
            attr.Add("x-transition:enter-start", "opacity-0 transform -translate-x-20");
            attr.Add("x-transition:enter-end", "opacity-100");
            attr.Add("x-transition:leave", "transition ease-in-out duration-150");
            attr.Add("x-transition:leave-star", "opacity-100");
            attr.Add("x-transition:leave-end", "opacity-0 transform -translate-x-20");
            attr.Add("x-on:click.away", "closeSideMenu");
            attr.Add("x-on:keydown.escape", "closeSideMenu");

            WrapContent(content, attr, output, classes, "fixed inset-y-0 z-20 flex-shrink-0 w-64 mt-16 overflow-y-auto bg-white dark:bg-gray-800 md:hidden");
        }

        void WrapContent(string content, TagHelperAttributeList attr, TagHelperOutput output, string cssCommon, string css)
        {
            output.Content.AppendHtml($@"<aside ");
            //AddClass(attr, css);
            foreach (var x in attr)
            {
                x.CopyTo(output.Content);
            }
            output.Content.AppendHtml("class=\"").AppendHtml(cssCommon).AppendHtml(" ").Append(css).AppendHtml("\"");
            output.Content.AppendHtmlLine(">");

            output.Content.AppendHtmlLine($@"<div class=""py-4 text-gray-500 dark:text-gray-400"">
<a class=""ml-6 text-lg font-bold text-gray-800 dark:text-gray-200"" href=""#"">{Name}</a>
<ul class=""mt-6"">");
            output.Content.AppendHtmlLine(content);
            output.Content.AppendHtmlLine($@"</ul></div></aside>");
        }
    }
}
