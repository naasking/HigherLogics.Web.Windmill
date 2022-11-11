using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// A table element.
    /// </summary>
    public class WindmillTableHeaderTagHelper : WindmillTagHelper
    {
        public WindmillTableHeaderTagHelper() : base("w-full overflow-x-auto")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = null;
            if (output.Attributes.TryGetAttribute("class", out var css))
                output.Attributes.Remove(css);

            output.PreContent.AppendHtml($@"<div class=""w-full overflow-x-auto""><table class=""w-full whitespace-no-wrap");
            css?.CopyTo(output.PreContent);
            output.PreContent.AppendHtmlLine(@"""><thead><tr class=""text-xs font-semibold tracking-wide text-left text-gray-500 uppercase border-b dark:border-gray-700 bg-gray-50 dark:text-gray-400 dark:bg-gray-800"">");

            output.PostContent.AppendHtml("</tr></thead>");
        }
    }
}
