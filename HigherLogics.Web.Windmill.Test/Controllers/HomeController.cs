using HigherLogics.Web.Chartjs;
using HigherLogics.Web.Windmill.Test.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
            return View(new GlobalViewModel { Page = "Forms" });
        }

        public IActionResult Cards()
        {
            return View(new GlobalViewModel { Page = "Cards" });
        }

        public IActionResult Buttons()
        {
            return View(new GlobalViewModel { Page = "Buttons" });
        }

        public IActionResult Modals()
        {
            return View(new GlobalViewModel { Page = "Modals" });
        }

        public IActionResult Tables()
        {
            return View(new GlobalViewModel { Page = "Tables" });
        }

        public IActionResult Pages()
        {
            return View(new GlobalViewModel { Page = "Pages" });
        }

        public IActionResult Charts()
        {
            var chart = new Chart
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
            return View(chart);
        }

        public IActionResult Login()
        {
            return View(new GlobalViewModel { Page = "Login" });
        }

        public IActionResult CreateAccount()
        {
            return View(new GlobalViewModel { Page = "CreateAccount" });
        }

        public IActionResult ForgotPassword()
        {
            return View(new GlobalViewModel { Page = "ForgotPassword" });
        }

        public IActionResult Blank()
        {
            return View(new GlobalViewModel { Page = "Blank" });
        }
    }
}