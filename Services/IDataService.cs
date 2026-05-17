using JaipurMeniral.Models;

namespace JaipurMeniral.Services
{
    public interface IDataService
    {
        List<Category> GetCategories();
        List<Product> GetProducts();
        List<Product> GetFeaturedProducts(int count = 8);
        List<Product> GetProductsByCategory(string categorySlug);
        Product? GetProductBySlug(string slug);
        List<Project> GetProjects();
        List<Faq> GetFaqs();
    }
}
