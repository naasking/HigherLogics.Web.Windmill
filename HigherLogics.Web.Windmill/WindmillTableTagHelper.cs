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
        public WindmillTableTagHelper() : base("w-full mb-8 overflow-hidden rounded-lg shadow-xs")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";
            base.Process(context, output);
        }
    }
}
