using JaipurMeniral.Services;
using JaipurMeniral.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace JaipurMeniral.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDataService _data;

        public ProductController(IDataService data)
        {
            _data = data;
        }

        public IActionResult Index(string? category, string? search, int page = 1)
        {
            const int pageSize = 12;
            var products = _data.GetProducts();

            if (!string.IsNullOrEmpty(category))
                products = products.Where(p => p.CategorySlug.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();

            if (!string.IsNullOrEmpty(search))
                products = products.Where(p =>
                    p.Name.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.CategoryName.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                    p.Tags.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();

            var total = products.Count;
            var totalPages = (int)Math.Ceiling(total / (double)pageSize);
            var paged = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            var vm = new ProductListViewModel
            {
                Products = paged,
                Categories = _data.GetCategories(),
                SelectedCategory = category,
                SearchTerm = search,
                CurrentPage = page,
                TotalPages = totalPages,
                TotalCount = total,
                PageSize = pageSize
            };

            ViewData["Title"] = "Products - Premium Sandstone | Mahakaleshwar Stones";
            return View(vm);
        }

        public IActionResult Details(string slug)
        {
            var product = _data.GetProductBySlug(slug);
            if (product == null) return NotFound();

            ViewData["Title"] = $"{product.Name} - Sandstone Product | Mahakaleshwar Stones";
            ViewBag.RelatedProducts = _data.GetProductsByCategory(product.CategorySlug)
                .Where(p => p.Slug != slug).Take(4).ToList();
            return View(product);
        }
    }
}
