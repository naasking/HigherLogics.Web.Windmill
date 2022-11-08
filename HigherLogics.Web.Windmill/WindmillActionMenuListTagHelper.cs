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
    public class WindmillActionMenuListTagHelper : WindmillTagHelper
    {
        public WindmillActionMenuListTagHelper() : base("absolute right-0 w-56 p-2 mt-2 space-y-2 text-gray-600 bg-white border border-gray-100 rounded-md shadow-md dark:text-gray-300 dark:border-gray-700 dark:bg-gray-700")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "template";

            AddClass(output.Attributes, BaseStyles);

            if (output.Attributes.TryGetAttribute("x-if", out var xif))
                output.Attributes.Remove(xif);
            output.Attributes.AddDefault("x-transition:leave", "transition ease-in duration-150");
            output.Attributes.AddDefault("x-transition:leave-start", "opacity-100");
            output.Attributes.AddDefault("x-transition:leave-end", "opacity-0");
            output.Attributes.AddDefault("aria-label", "submenu");

            output.PreContent.AppendHtml("<ul ");
            foreach(var attr in output.Attributes)
            {
                attr.CopyTo(output.PreContent);
            }
            output.PreContent.AppendHtmlLine(">");
            output.Attributes.Clear();

            if (xif != null)
                output.Attributes.Add(xif);
            else
                output.Attributes.Add("x-if", "toggleNotificationsMenu");

        }
    }
}
