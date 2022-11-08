﻿using HigherLogics.Web.Chartjs;

namespace HigherLogics.Web.Windmill.Test.Models
{
    public class ChartViewModel : GlobalViewModel
    {
        public Chart Pie { get; set; }
        public Chart Line { get; set; }
        public Chart Bar { get; set; }
    }
}
