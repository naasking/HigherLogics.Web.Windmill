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
    /// The container for a windmill user interface.
    /// </summary>
    public class WindmillContainerTagHelper : WindmillTagHelper
    {
        public WindmillContainerTagHelper() : base("flex h-screen bg-gray-50 dark:bg-gray-900")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);

            output.Attributes.AddDefault(":class", "{ 'overflow-hidden': isSideMenuOpen}");
        }
    }
}
