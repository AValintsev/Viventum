using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Viventum.Models;
using Viventum.Options;
using Viventum.Services.Interfaces;

namespace Viventum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEmailSender _emailSender;
        private readonly EmailSenderSettings _emailSenderSettings;

        public HomeController(
            ILogger<HomeController> logger,
            IEmailSender emailSender,
            EmailSenderSettings emailSenderSettings)
        {
            _logger = logger;
            _emailSender = emailSender;
            _emailSenderSettings = emailSenderSettings;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<PartialViewResult> ContactForm(ContactModel model)
        {
            if (ModelState.IsValid)
            {
                var html = $"<div>Hi, you have new contact form request:" +
                    $"<ul>" +
                    $"<li>Name: {model.Name}</li>" +
                    $"<li>Company: {model.Company}</li>" +
                    $"<li>Email: {model.Email}</li>" +
                    $"<li>Subject: {model.Subject}</li>" +
                    $"<li>Message: {model.Message}</li>" +
                    $"</ul>" +
                    $"</div>";

                try
                {
                    if (!string.IsNullOrWhiteSpace(_emailSenderSettings.FolderPath))
                    {
                        System.IO.File.WriteAllText(
                            Path.Combine(_emailSenderSettings.FolderPath,
                            $"{DateTime.Now.ToString().Replace(".", "-").Replace(" ", "-").Replace(":", "-")}.html"),
                            html);
                    }
                }
                catch (Exception e)
                {
                    return PartialView("_Error");
                }
                finally
                {
                    await _emailSender.SendEmailToAdminAsync("New contact request", html);
                }

                return PartialView("_Success");
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
