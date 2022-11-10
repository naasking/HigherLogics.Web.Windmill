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
    /// The clickable element that expands and collapses a menu in the sidebar.
    /// </summary>
    public class WindmillSidebarMenuTitleTagHelper : WindmillTagHelper
    {
        public WindmillSidebarMenuTitleTagHelper() : base("inline-flex items-center justify-between w-full text-sm font-semibold transition-colors duration-150 hover:text-gray-800 dark:hover:text-gray-200")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //FIXME: need to abstract out the togglePages and isPagesOpen functionality. The windmill-sidebar-menu should have a Name property which will be used
            //as the variable name, and will need to add a toggleMenu(Name). The same Name will need to be assigned to windmill-sidebar-menu as well, since that checks
            //the state via x-if. Could assign or propagate a name automatically via a script that runs on page load:
            //  document.querySelectorAll("button[data-XX]+template").forEach(tmpl => tmpl.setAttribute("x-if", tmpl.previousElement.getAttribute("name"));
            output.TagName = "button";
            output.Attributes.Add("x-on:click", "togglePagesMenu");
            output.Attributes.Add("aria-haspopup", "true");
            output.PostContent.AppendHtmlLine(@"<svg class=""w-4 h-4"" aria-hidden=""true"" fill=""currentColor"" viewBox=""0 0 20 20"">
    <path fill-rule=""evenodd"" d=""M5.293 7.293a1 1 0 011.414 0L10 10.586l3.293-3.293a1 1 0 111.414 1.414l-4 4a1 1 0 01-1.414 0l-4-4a1 1 0 010-1.414z"" clip-rule=""evenodd""></path>
</svg>");
            base.Process(context, output);
        }
    }
}
