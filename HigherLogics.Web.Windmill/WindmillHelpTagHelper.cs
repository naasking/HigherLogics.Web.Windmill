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
    /// A feedback note.
    /// </summary>
    public class WindmillHelpTagHelper : WindmillTagHelper
    {
        public WindmillHelpTagHelper() : base("")
        {
        }

        /// <summary>
        /// True if the element should render, false otherwise.
        /// </summary>
        public bool Visible { get; set; }

        /// <summary>
        /// The type of feedback being provided.
        /// </summary>
        public ValidationType Type { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (!Visible)
            {
                output.SuppressOutput();
            }
            else
            {
                output.TagName = "span";
                switch (Type)
                {
                    case ValidationType.Notice:
                        BaseStyles = "text-xs text-gray-600 dark:text-gray-400";
                        break;
                    case ValidationType.Valid:
                        BaseStyles = "text-xs text-green-600 dark:text-green-400";
                        break;
                    case ValidationType.Error:
                        BaseStyles = "text-xs text-red-600 dark:text-red-400";
                        break;
                }
                base.Process(context, output);
            }
        }
    }
}
