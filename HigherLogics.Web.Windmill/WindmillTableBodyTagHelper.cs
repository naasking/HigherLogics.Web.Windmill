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
    /// A table body element.
    /// </summary>
    public class WindmillTableBodyTagHelper : WindmillTagHelper
    {
        public WindmillTableBodyTagHelper() : base("bg-white divide-y dark:divide-gray-700 dark:bg-gray-800")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "tbody";
            base.Process(context, output);

            output.PostContent.AppendHtmlLine("</table>");
        }
    }
}
