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
    public class WindmillInputGroupTagHelper : WindmillTagHelper
    {
        public WindmillInputGroupTagHelper() : base("relative text-gray-500 focus-within:text-purple-600")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);
        }
    }
}
