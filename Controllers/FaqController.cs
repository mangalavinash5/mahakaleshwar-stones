using JaipurMeniral.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class FaqController : Controller
    {
        private readonly IDataService _data;

        public FaqController(IDataService data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            var faqs = _data.GetFaqs();
            ViewData["Title"] = "FAQ - Mahakaleshwar Stones | Sandstone Export Questions";
            return View(faqs);
        }
    }
}
