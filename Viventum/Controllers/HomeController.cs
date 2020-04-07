using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Viventum.Models;

namespace Viventum.Controllers
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
            return View();
        }

        [HttpPost]
        public PartialViewResult ContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {

                var c = model.Company;
                var e = model.Email;
                var m = model.Message;

                // Send an email
                // Save to file

            }

            return PartialView("_ContactForm", new ContactModel());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
