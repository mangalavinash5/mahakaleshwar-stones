using JaipurMeniral.Models;
using JaipurMeniral.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class InquiryController : Controller
    {
        private readonly IEmailService _email;

        public InquiryController(IEmailService email)
        {
            _email = email;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromForm] InquiryModel model)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage);
                return Json(new { success = false, message = string.Join(", ", errors) });
            }

            var result = await _email.SendInquiryEmailAsync(model);
            return Json(new
            {
                success = result,
                message = result
                    ? "Thank you! Your inquiry has been sent successfully. Our team will contact you within 24 hours."
                    : "Failed to send inquiry. Please try again or contact us via WhatsApp."
            });
        }
    }
}
