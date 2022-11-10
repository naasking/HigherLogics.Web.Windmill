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
    /// A card. The padding and shadow are left unset.
    /// </summary>
    public class WindmillCardTagHelper : WindmillTagHelper
    {
        public WindmillCardTagHelper() : base("rounded-lg shadow-xs")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            base.Process(context, output);
        }
    }
}
