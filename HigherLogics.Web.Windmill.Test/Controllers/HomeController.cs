using HigherLogics.Web.Chartjs;
using HigherLogics.Web.Windmill.Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection.Emit;

namespace HigherLogics.Web.Windmill.Test.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return Redirect(Url.Action("Blank", "Home"));
            //return View(new GlobalTemplate { Page = "Index" });
        }

        public IActionResult Forms()
        {
            return View(new GlobalViewModel("Forms"));
        }

        public IActionResult Cards()
        {
            return View(new GlobalViewModel("Cards"));
        }

        public IActionResult Buttons()
        {
            return View(new GlobalViewModel("Buttons"));
        }

        public IActionResult Modals()
        {
            return View(new GlobalViewModel("Modals"));
        }

        public IActionResult Tables()
        {
            return View(new TableViewModel());
        }

        public IActionResult Pages()
        {
            return View(new GlobalViewModel("Pages"));
        }

        public IActionResult Charts()
        {

            var bar = new Chart
            {
                Type = "bar",
                Options = new ChartOptions { Responsive = true, Legend = new ChartLegend { Display = false } },
                Data = new ChartData
                {
                    Labels = new[] { "January", "February", "March", "April", "May", "June", "July" },
                    Datasets = new[]
                    {
                        new ChartDataset
                        {
                            Label = "Shoes",
                            BackgroundColors = new[] { "#0694a2" },
                            BorderWidth = 1,
                            Data = new object[] { -3, 14, 52, 74, 33, 90, 70 },
                        },
                        new ChartDataset
                        {
                            Label = "Bags",
                            BackgroundColors = new[] { "#7e3af2" },
                            BorderWidth = 1,
                            Data = new object[] { 66, 33, 43, 12, 54, 62, 84 },
                        },
                    },
                }
            };
            var line = new Chart
            {
                Type = "line",
                Options = new ChartOptions
                {
                    Responsive = true,
                    Legend = new ChartLegend { Display = false },
                    Tooltips = new ChartPlugin { Mode = "index", Intersect = false },
                    Hover = new ChartPlugin { Mode = "nearest", Intersect = true },
                    Scales = new ChartScales
                    {
                        X = new ChartAxis { Display = true, DisplayLabel = true, Label = "Month" },
                        Y = new ChartAxis { Display = true, DisplayLabel = true, Label = "Value" },
                    },
                },
                Data = new ChartData
                {
                    Labels = new[] { "January", "February", "March", "April", "May", "June", "July" },
                    Datasets = new[]
                    {
                        new ChartDataset
                        {
                            Label = "Organic",
                            BackgroundColors = new[] { "#0694a2", },
                            BorderColors = new[] { "#0694a2", },
                            Data = new object[] { 43, 48, 40, 54, 67, 73, 70 },
                            Fill = false,
                        },
                        new ChartDataset
                        {
                            Label = "Organic",
                            BackgroundColors = new[] { "#7e3af2", },
                            BorderColors = new[] { "#7e3af2", },
                            Data = new object[] { 24, 50, 64, 74, 52, 51, 65 },
                            Fill = false,
                        },
                    },
                },
            };
            var pie = new Chart
            {
                Type = "doughnut",
                Options = new ChartOptions
                {
                    Responsive = true,
                    CutoutPercentage = 80,
                    Legend = new ChartLegend { Display = false },
                },
                Data = new ChartData
                {
                    Labels = new[] { "Shoes", "Shirts", "Bags", },
                    Datasets = new[]
                    {
                        new ChartDataset
                        {
                            Label = "Dataset 1",
                            BackgroundColors = new[] { "#0694a2", "#1c64f2", "#7e3af2" },
                            Data = new object[] { 33, 33, 33 },
                        }
                    },
                },
            };
            return View(new ChartViewModel
            {
                Bar = bar,
                Line = line,
                Pie = pie,
            });
        }

        public IActionResult Login()
        {
            return View(new GlobalViewModel("Login"));
        }

        public IActionResult CreateAccount()
        {
            return View(new GlobalViewModel("CreateAccount"));
        }

        public IActionResult ForgotPassword()
        {
            return View(new GlobalViewModel("ForgotPassword"));
        }

        public IActionResult Blank()
        {
            return View(new GlobalViewModel("Blank"));
        }
    }
}