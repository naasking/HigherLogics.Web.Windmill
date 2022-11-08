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
    public class WindmillMainTagHelper : WindmillTagHelper
    {
        public WindmillMainTagHelper() : base("h-full pb-16 overflow-y-auto")
        {
        }

        /// <summary>
        /// True if you want a truly blank slate, false if you want the default container.
        /// </summary>
        public bool Blank { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "main";
            base.Process(context, output);

            if (!Blank)
            {
                output.PreContent.AppendHtmlLine(@"<div class=""container px-6 mx-auto grid"">");
                output.PostContent.AppendHtmlLine("</div>");
            }
        }
    }
}
