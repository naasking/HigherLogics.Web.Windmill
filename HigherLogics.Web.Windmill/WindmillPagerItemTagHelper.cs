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
    /// A card. The padding and shadow are left unset.
    /// </summary>
    public class WindmillPagerItemTagHelper : WindmillTagHelper
    {
        public WindmillPagerItemTagHelper() : base("")
        {
        }
        public string? Type { get; set; }
        public bool Active { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "li";
            base.Process(context, output);

            if (Active)
                output.PreContent.AppendHtml($@"<{Type} class=""px-3 py-1 text-white transition-colors duration-150 bg-purple-600 border border-r-0 border-purple-600 rounded-md focus:outline-none focus:shadow-outline-purple"">");
            else
                output.PreContent.AppendHtml($@"<{Type} class=""px-3 py-1 rounded-md focus:outline-none focus:shadow-outline-purple"">");
            output.PostContent.AppendHtmlLine($"</{Type}");
        }
    }
}
