using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HigherLogics.Web.Windmill
{
    internal static class Extensions
    {
        public static void AddDefault(this TagHelperAttributeList attrs, string name, string value)
        {
            if (!attrs.TryGetAttribute(name, out var _))
                attrs.Add(new TagHelperAttribute(name, value));
        }


        public static void RemoveAttribute(this TagHelperOutput output, string name, out TagHelperAttribute attr)
        {
            if (output.Attributes.TryGetAttribute(name, out attr))
                output.Attributes.Remove(attr);
        }

        public static void GetInputAttributes(this TagHelperOutput output,
            out TagHelperAttribute name,
            out TagHelperAttribute value,
            out TagHelperAttribute disabled,
            out TagHelperAttribute required,
            out TagHelperAttribute readOnly,
            out TagHelperAttribute placeholder)
        {
            RemoveAttribute(output, "name", out name);
            RemoveAttribute(output, "value", out value);
            RemoveAttribute(output, "disabled", out disabled);
            RemoveAttribute(output, "required", out required);
            RemoveAttribute(output, "readonly", out readOnly);
            RemoveAttribute(output, "placeholder", out placeholder);
        }

    }
}
