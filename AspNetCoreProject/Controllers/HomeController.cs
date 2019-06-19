using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreProject.Models;
using DataLayer;

namespace AspNetCoreProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly EFDBContext _context;

        public HomeController(EFDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var homeModel = new HomeModel() { Message = "Hello from Home Model" };
            ViewBag.Text = homeModel.Message;
            return View(homeModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your process history.";
            var coffe = new CoffeeModel()
            {
                    Id = 1,
                    StartDate = DateTime.Now.Date,
                    EndDate = null,
                    Sort = "Arabica"
            };
            _context.Add(coffe);
            return View(coffe);
        }

        public string ProcessResult(int Id, DateTime startDate, DateTime endDate, string sort)
        {
            var coffe = new CoffeeModel()
            {
                Id = Id,
                StartDate = startDate,
                EndDate = endDate,
                Sort = sort
            };
            return $"{Id} {startDate} {endDate} {sort}";

        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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
