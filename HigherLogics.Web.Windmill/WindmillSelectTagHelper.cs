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
    /// A select input.
    /// </summary>
    public class WindmillSelectTagHelper : WindmillTagHelper
    {
        public WindmillSelectTagHelper() : base("w-full mt-1 text-sm dark:text-gray-300 dark:border-gray-600 dark:bg-gray-700 focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:focus:shadow-outline-gray")
        {
        }
        public bool Multiple { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "select";
            if (Multiple)
            {
                BaseStyles += " form-multiselect";
                output.Attributes.Add("multiple", "");
            }
            else
            {
                BaseStyles += " form-select";
            }
            base.Process(context, output);
        }
    }
}
