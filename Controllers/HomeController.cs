using JaipurMeniral.Models;
using JaipurMeniral.Services;
using JaipurMeniral.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDataService _data;
        private readonly IEmailService _email;

        public HomeController(IDataService data, IEmailService email)
        {
            _data = data;
            _email = email;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Categories = _data.GetCategories(),
                FeaturedProducts = _data.GetFeaturedProducts(8),
                Projects = _data.GetProjects().Take(6).ToList(),
                FaqPreview = _data.GetFaqs().Take(5).ToList(),
                Inquiry = new InquiryModel()
            };
            ViewData["Title"] = "Mahakaleshwar Stones - Premium Sandstone Manufacturer & Exporter from India";
            return View(vm);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
