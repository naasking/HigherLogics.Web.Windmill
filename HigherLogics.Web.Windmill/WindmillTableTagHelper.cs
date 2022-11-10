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
    public class WindmillTableTagHelper : WindmillTagHelper
    {
        public WindmillTableTagHelper() : base("w-full whitespace-no-wrap")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.PreContent.AppendHtml($@"<div class=""w-full overflow-hidden rounded-lg shadow-xs""><div class=""w-full overflow-x-auto"">");

            output.TagName = "table";
            base.Process(context, output);

            output.PostContent.AppendHtml($@"</div></div>");
        }
    }
}
