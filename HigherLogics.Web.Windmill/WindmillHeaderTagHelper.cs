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
    /// The header that shows at the top of the screen.
    /// </summary>
    public class WindmillHeaderTagHelper : WindmillTagHelper
    {
        public WindmillHeaderTagHelper() : base("z-10 py-4 bg-white shadow-md dark:bg-gray-800")
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "header";
            base.Process(context, output);

            //FIXME: copy any attributes to the hamburger?

            // mobile hamburger
            output.PreContent.AppendHtml($@"<div class=""container flex items-center justify-between h-full px-6 mx-auto text-purple-600 dark:text-purple-300"">
<button class=""p-1 -ml-1 mr-5 rounded-md md:hidden focus:outline-none focus:shadow-outline-purple"" @click=""toggleSideMenu"" aria-label=""Menu"">
<svg class=""w-6 h-6"" aria-hidden=""true"" fill=""currentColor"" viewBox=""0 0 20 20"">
    <path fill-rule=""evenodd"" d=""M3 5a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 10a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1zM3 15a1 1 0 011-1h12a1 1 0 110 2H4a1 1 0 01-1-1z"" clip-rule=""evenodd""></path>
</svg>
</button>");
            output.PostContent.AppendHtmlLine("</div>");
        }
    }
}
