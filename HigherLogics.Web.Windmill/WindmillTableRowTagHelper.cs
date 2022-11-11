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
    /// A table row element.
    /// </summary>
    public class WindmillTableRowTagHelper : WindmillTagHelper
    {
        public WindmillTableRowTagHelper() : base("text-gray-700 dark:text-gray-400")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "tr";
            base.Process(context, output);
        }
    }
}
