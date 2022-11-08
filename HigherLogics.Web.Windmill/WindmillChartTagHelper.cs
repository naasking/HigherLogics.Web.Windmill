using System;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using HigherLogics.Web.Chartjs;

namespace HigherLogics.Web.Windmill
{
    public class WindmillChartTagHelper : WindmillTagHelper
    {
        public WindmillChartTagHelper() : base("chartjs-render-monitor")
        {
        }

        /// <summary>
        /// The chart data.
        /// </summary>
        /// <seealso cref="https://www.chartjs.org/docs/latest/getting-started/usage.html"/>
        public Chart Chart { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "canvas";
            var id = output.Attributes["id"];
            if (id?.Value == null)
                throw new ArgumentNullException("Chart must have an 'id' attribute assigned");
            output.PostElement.AppendHtml(Chart.ToScript(id.Value.ToString()));
            base.Process(context, output);
        }
    }
}
