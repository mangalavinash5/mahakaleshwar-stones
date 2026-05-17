using JaipurMeniral.Models;

namespace JaipurMeniral.ViewModels
{
    public class HomeViewModel
    {
        public List<Category> Categories { get; set; } = new();
        public List<Product> FeaturedProducts { get; set; } = new();
        public List<Project> Projects { get; set; } = new();
        public List<Faq> FaqPreview { get; set; } = new();
        public InquiryModel Inquiry { get; set; } = new();
    }
}
