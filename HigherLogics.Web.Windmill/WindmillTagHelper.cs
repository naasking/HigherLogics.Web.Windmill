using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text.Encodings.Web;

namespace HigherLogics.Web.Windmill
{
    /// <summary>
    /// Base class for all windmill tag helpers.
    /// </summary>
    public abstract class WindmillTagHelper : TagHelper
    {
        protected WindmillTagHelper(string baseStyles)
        {
            BaseStyles = baseStyles;
        }
        protected string BaseStyles { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            AddClass(output.Attributes, BaseStyles);
        }

        protected static void AddClass(TagHelperAttributeList attr, string styles)
        {
            if (string.IsNullOrEmpty(styles))
                return;
            var encoded = HtmlEncoder.Default.Encode(styles);
            if (attr.TryGetAttribute("class", out var className))
            {
                var classes = ToString(className.Value, HtmlEncoder.Default);
                attr.SetAttribute(new TagHelperAttribute(className.Name, encoded + ' ' + classes, className.ValueStyle));
            }
            else
            {
                attr.Add("class", encoded);
            }
        }

        protected static string ToString(object attr, HtmlEncoder encoder)
        {
            switch (attr)
            {
                case string s:
                    return encoder.Encode(s);
                case HtmlString h:
                    return encoder.Encode(h.Value);
                case IHtmlContent c:
                    using (var buf = new StringWriter())
                    {
                        c.WriteTo(buf, encoder);
                        return buf.ToString();
                    }
                default:
                    return encoder.Encode(attr?.ToString() ?? "");
            }
        }
    }
}