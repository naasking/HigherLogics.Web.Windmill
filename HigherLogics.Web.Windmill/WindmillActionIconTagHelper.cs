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
    public class WindmillActionIconTagHelper : WindmillTagHelper
    {
        public WindmillActionIconTagHelper() : base("relative align-middle rounded-md focus:outline-none focus:shadow-outline-purple")
        {
        }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "button";
            base.Process(context, output);

            //output.Attributes.AddDefault("@click", "toggleNotificationsMenu");
            //output.Attributes.AddDefault("@keydown.escape", "closeNotificationsMenu");
            output.Attributes.AddDefault("aria-label", "Notifications");
            output.Attributes.AddDefault("aria-haspopup", "true");
        }
    }
}
