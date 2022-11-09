using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using HigherLogics.Web.Chartjs;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace HigherLogics.Web.Windmill
{
    public class WindmillModalTagHelper : WindmillTagHelper
    {
        public WindmillModalTagHelper() : base("fixed inset-0 z-30 sm:items-center sm:justify-center flex items-end bg-black bg-opacity-50")
        {
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // a modal is a nested div, the outer container must be placed near the closing </body> tag, and it
            // blocks the whole screen. the inner div is the actual pop-up that shows a message and some actions
            // to process the modal
            output.TagName = "div";
            base.Process(context, output);
            output.Attributes.AddDefault("x-show", "isModalOpen");
            output.Attributes.AddDefault("x-transition:enter", "transition ease-out duration-150");
            output.Attributes.AddDefault("x-transition:enter-start", "opacity-0");
            output.Attributes.AddDefault("x-transition:enter-end", "opacity-100");
            output.Attributes.AddDefault("x-transition:leave", "transition ease-in duration-150");
            output.Attributes.AddDefault("x-transition:leave-start", "opacity-100");
            output.Attributes.AddDefault("x-transition:leave-end", "opacity-0");

            output.PreContent.AppendHtmlLine($@"
<div x-show=""isModalOpen""
    x-transition:enter=""transition ease-out duration-150""
    x-transition:enter-start=""opacity-0 transform translate-y-1/2""
    x-transition:enter-end=""opacity-100""
    x-transition:leave=""transition ease-in duration-150""
    x-transition:leave-start=""opacity-100""
    x-transition:leave-end=""opacity-0 transform translate-y-1/2""
    x-on:click.away=""closeModal""
    x-on:keydown.escape=""closeModal""
    class=""w-full px-6 py-4 overflow-hidden bg-white rounded-t-lg dark:bg-gray-800 sm:rounded-lg sm:m-4 sm:max-w-xl""
    role=""dialog""
    id=""modal""
    >");
            output.PostContent.AppendHtmlLine("</div>");
        }
    }
}
