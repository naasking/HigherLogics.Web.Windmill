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
    /// An input element.
    /// </summary>
    public class WindmillInputTagHelper : WindmillTagHelper
    {
        public WindmillInputTagHelper() : base("w-full text-sm focus:outline-none form-input dark:text-gray-300")
        {
        }
        
        /// <summary>
        /// The input type.
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// The validation state.
        /// </summary>
        public ValidationType ValidationState { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //FIXME: should add input group support, the way I did for buttons?
            output.TagName = "input";
            if (string.IsNullOrEmpty(Type))
                Type = "text";
            output.Attributes.Add("type", Type);
            BaseStyles += ValidationState.GetInputValidationClasses();
            base.Process(context, output);
        }
    }
}
