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
    /// The type of grouping being applied.
    /// </summary>
    public enum InputGroupType
    {
        /// <summary>
        /// The input is grouped with an icon that's inset into the field.
        /// </summary>
        Icon,
        /// <summary>
        /// The input is grouped with a button that's inset into the field.
        /// </summary>
        Button,
    }

    /// <summary>
    /// Place an element inset into an input.
    /// </summary>
    public class WindmillInputGroupTagHelper : WindmillTagHelper
    {
        public WindmillInputGroupTagHelper() : base("relative")
        {
        }

        /// <summary>
        /// The type of group being defined.
        /// </summary>
        public InputGroupType GroupType { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            if (GroupType == InputGroupType.Icon)
            {
                BaseStyles += " focus-within:text-purple-600 dark:focus-within:text-purple-400";
            }
            base.Process(context, output);
        }
    }
}
