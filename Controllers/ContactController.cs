using JaipurMeniral.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class ContactController : Controller
    {
        private readonly IEmailService _email;
        private readonly IConfiguration _config;

        public ContactController(IEmailService email, IConfiguration config)
        {
            _email = email;
            _config = config;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Contact Us - Mahakaleshwar Stones | Get In Touch";
            ViewBag.MapEmbed = _config["CompanySettings:GoogleMapEmbed"];
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] string name, [FromForm] string email,
            [FromForm] string phone, [FromForm] string subject, [FromForm] string message)
        {
            if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
                return Json(new { success = false, message = "Please fill all required fields." });

            var result = await _email.SendContactEmailAsync(name, email, phone ?? "", subject ?? "Contact Inquiry", message);
            return Json(new { success = result, message = result ? "Your message has been sent! We'll respond within 24 hours." : "Failed to send. Please try again or contact us directly." });
        }
    }
}
