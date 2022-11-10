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
    /// The list of actions that appears in the header.
    /// </summary>
    public class WindmillActionListTagHelper : WindmillTagHelper
    {
        public WindmillActionListTagHelper() : base("flex items-center flex-shrink-0 space-x-6")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "ul";
            base.Process(context, output);
        }
    }
}
