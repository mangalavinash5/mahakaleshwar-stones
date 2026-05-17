using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "About Us - Mahakaleshwar Stones | Sandstone Exporter India";
            return View();
        }
    }
}
