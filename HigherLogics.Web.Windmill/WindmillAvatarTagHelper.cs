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
    /// An avatar element.
    /// </summary>
    public class WindmillAvatarTagHelper : WindmillTagHelper
    {
        public WindmillAvatarTagHelper() : base("object-cover rounded-full")
        {
        }

        public string? Src { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            if (!output.Attributes.TryGetAttribute("alt", out var _))
                output.Attributes.Add("alt", "avatar");
            if (Src != null)
                output.Attributes.Add("src", Src);
            if (!output.Attributes.TryGetAttribute("aria-hidden", out var _))
                output.Attributes.Add("aria-hidden", "true");
            base.Process(context, output);
        }
    }
}
