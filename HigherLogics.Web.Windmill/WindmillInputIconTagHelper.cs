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
    /// An icon that will be inset into a input.
    /// </summary>
    public class WindmillInputIconTagHelper : WindmillTagHelper
    {
        public WindmillInputIconTagHelper() : base("absolute inset-y-0 flex items-center pointer-events-none")
        {
        }

        /// <summary>
        /// The grouping layout.
        /// </summary>
        public GroupLayout Layout { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if (Layout == GroupLayout.Left)
                BaseStyles += " ml-3";
            else if (Layout == GroupLayout.Right)
                BaseStyles += " mr-3 right-0";
            base.Process(context, output);
        }
    }
}
