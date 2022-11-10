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
    /// A radio input.
    /// </summary>
    public class WindmillRadioTagHelper : WindmillTagHelper
    {
        public WindmillRadioTagHelper() : base("inline-flex items-center text-gray-600 dark:text-gray-400")
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "label";
            base.Process(context, output);
            var content = ToString(output.GetChildContentAsync().Result, HtmlEncoder.Default);
            output.GetInputAttributes(out var name, out var value, out var disabled, out var required, out var readOnly, out var placeholder);
            output.RemoveAttribute("checked", out var checkd);
            output.Content.Clear();
            output.Content.AppendHtml(@"<input type=""radio"" class=""text-purple-600 form-radio focus:border-purple-400 focus:outline-none focus:shadow-outline-purple dark:focus:shadow-outline-gray""");

            name?.CopyTo(output.Content);
            value?.CopyTo(output.Content);
            disabled?.CopyTo(output.Content);
            checkd?.CopyTo(output.Content);
            readOnly?.CopyTo(output.Content);
            required?.CopyTo(output.Content);
            placeholder?.CopyTo(output.Content);

            output.Content.AppendHtml(@" /><span class=""ml-2"">");
            output.Content.AppendHtml(content ?? "");
            output.Content.AppendHtmlLine("</span>");
        }
    }
}
