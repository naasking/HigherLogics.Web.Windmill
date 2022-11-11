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

        static IEnumerable<Client> users = new[]
        {
            new Client("Hans Burger", "10x Developer", 863.45M, ClientStatus.Approved, new DateTime(2020, 10, 6), "https://images.unsplash.com/flagged/photo-1570612861542-284f4c12e75f?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
            new Client("Jolina Angelie", "Unemployed", 369.95M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1494790108377-be9c29b29330?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&facepad=3&fit=facearea&s=707b9c33066bf8808c934c8ab394dff6"),
            new Client("Sarah Curry", "Designer", 86M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1551069613-1904dbdcda11?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
            new Client("Rulia Joberts", "Actress", 1276.45M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1551006917-3b4c078c47c9?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
            new Client("Wenzel Dashington", "Actor", 863.45M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1546456073-6712f79251bb?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
            new Client("Dave Li", "Influencer", 863.45M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1502720705749-871143f0e671?ixlib=rb-0.3.5&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&s=b8377ca9f985d80264279f277f3a67f5"),
            new Client("Maria Ramovic", "Runner", 863.45M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1531746020798-e6953c6e8e04?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
            new Client("Hitney Wouston", "Singer", 863.45M, ClientStatus.Pending, new DateTime(2020, 10, 6), "https://images.unsplash.com/photo-1566411520896-01e7ca4726af?ixlib=rb-1.2.1&q=80&fm=jpg&crop=entropy&cs=tinysrgb&w=200&fit=max&ixid=eyJhcHBfaWQiOjE3Nzg0fQ"),
        };

        public IActionResult Tables()
        {
            return View(new TableViewModel(users));
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