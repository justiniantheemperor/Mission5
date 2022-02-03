using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission5.Models;
using System.Diagnostics;
using System.Linq;

namespace Mission5.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //
        private MovieApplicationContext movieContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, MovieApplicationContext someName)
        {
            _logger = logger;
            movieContext = someName;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Movies()
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            return View();
        }
        [HttpPost]
        public IActionResult Movies(ApplicationResponse response)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            movieContext.Add(response);
            movieContext.SaveChanges();

            return View();
        }

        public IActionResult Waitlist()
        {
            var applications = movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
