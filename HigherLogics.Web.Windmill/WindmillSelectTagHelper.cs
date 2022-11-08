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
    public class WindmillSelectTagHelper : WindmillTagHelper
    {
        public WindmillSelectTagHelper() : base("text-purple-600 form-radio focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:focus:shadow-outline-gray")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            var multiple = output.Attributes.TryGetAttribute("multiple", out _);
            if (multiple)
                BaseStyles += " form-multiselect";
            else
                BaseStyles += " form-select";
            base.Process(context, output);
        }
    }
}
