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
    /// A textarea element.
    /// </summary>
    public class WindmillTextareaTagHelper : WindmillTagHelper
    {
        public WindmillTextareaTagHelper() : base("w-full mt-1 text-sm dark:text-gray-300 form-textarea focus:outline-none")
        {
        }

        /// <summary>
        /// The current validation state of this item.
        /// </summary>
        public ValidationType ValidationState { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "textarea";
            BaseStyles += ValidationState.GetInputValidationClasses();
            base.Process(context, output);
        }
    }
}
