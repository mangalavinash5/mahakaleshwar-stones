using JaipurMeniral.Models;
using Newtonsoft.Json;

namespace JaipurMeniral.Services
{
    public class DataService : IDataService
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<DataService> _logger;

        public DataService(IWebHostEnvironment env, ILogger<DataService> logger)
        {
            _env = env;
            _logger = logger;
        }

        private T LoadJson<T>(string fileName) where T : new()
        {
            try
            {
                var path = Path.Combine(_env.WebRootPath, "data", fileName);
                if (!File.Exists(path)) return new T();
                var json = File.ReadAllText(path);
                return JsonConvert.DeserializeObject<T>(json) ?? new T();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error loading {FileName}", fileName);
                return new T();
            }
        }

        public List<Category> GetCategories() => LoadJson<List<Category>>("categories.json");
        public List<Product> GetProducts() => LoadJson<List<Product>>("products.json");
        public List<Faq> GetFaqs() => LoadJson<List<Faq>>("faqs.json");
        public List<Project> GetProjects() => LoadJson<List<Project>>("projects.json");

        public List<Product> GetFeaturedProducts(int count = 8)
            => GetProducts().Where(p => p.IsFeatured).Take(count).ToList();

        public List<Product> GetProductsByCategory(string categorySlug)
            => GetProducts().Where(p => p.CategorySlug.Equals(categorySlug, StringComparison.OrdinalIgnoreCase)).ToList();

        public Product? GetProductBySlug(string slug)
            => GetProducts().FirstOrDefault(p => p.Slug.Equals(slug, StringComparison.OrdinalIgnoreCase));
    }
}
