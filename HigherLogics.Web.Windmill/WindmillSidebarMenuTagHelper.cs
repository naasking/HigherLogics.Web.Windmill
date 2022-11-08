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
    /// A sidebar item that is also a menu.
    /// </summary>
    public class WindmillSidebarMenuTagHelper : WindmillTagHelper
    {
        public WindmillSidebarMenuTagHelper() : base("relative px-6 py-3")
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // sidebar = link | menu
            // menu = title * list<menu-item>

            output.TagName = "li";
            base.Process(context, output);
        }
    }
}
