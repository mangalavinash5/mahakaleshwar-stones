using JaipurMeniral.Services;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IDataService _data;

        public ProjectController(IDataService data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            var projects = _data.GetProjects();
            ViewData["Title"] = "Our Projects - Mahakaleshwar Stones | Stone Work Portfolio";
            return View(projects);
        }
    }
}
