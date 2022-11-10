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
    /// A label element associated with a form input.
    /// </summary>
    public class WindmillLabelTagHelper : WindmillTagHelper
    {
        public WindmillLabelTagHelper() : base("text-sm")
        {
        }

        /// <summary>
        /// The label text description.
        /// </summary>
        public string? Text { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "label";
            if (Text != null)
                output.PreContent.AppendHtml($@"<span class=""text-gray-700 dark:text-gray-400"">{Text}</span>");
            base.Process(context, output);
        }
    }
}
