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

            return View(new ApplicationResponse());
        }
        [HttpPost]
        public IActionResult Movies(ApplicationResponse response)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            if (ModelState.IsValid)
            {
                movieContext.Add(response);
                movieContext.SaveChanges();
            }
            else //If Invalid
            {
                return View(response);
            }

 

            return RedirectToAction("Waitlist");
        }

        // display all the values
        public IActionResult Waitlist()
        {
            var applications = movieContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(applications);
        }

        //edit function
        [HttpGet]
        public IActionResult Edit(int applicationid)
        {
            ViewBag.Categories = movieContext.Categories.ToList();

            var application = movieContext.Responses.Single(x => x.Id == applicationid);

            return View("Movies", application);
        }

        [HttpPost]
        public IActionResult Edit(ApplicationResponse change)
        {

            movieContext.Update(change);
            movieContext.SaveChanges();

            return RedirectToAction("Waitlist");
        }

        //delete function

        [HttpGet]
        public IActionResult Delete(int applicationid)
        {
            var application = movieContext.Responses.Single(x => x.Id == applicationid);

            return View(application);
        }

        [HttpPost]
        public IActionResult Delete(ApplicationResponse response)
        {
            movieContext.Responses.Remove(response);
            movieContext.SaveChanges();

            return RedirectToAction("Waitlist");
        }



        // irrelevant to project, ignore

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
