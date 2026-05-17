namespace JaipurMeniral.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Slug { get; set; } = "";
        public string CategorySlug { get; set; } = "";
        public string CategoryName { get; set; } = "";
        public string Description { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public List<string> Images { get; set; } = new();
        public string FinishType { get; set; } = "";
        public List<string> FinishTypes { get; set; } = new();
        public string Size { get; set; } = "";
        public List<string> Sizes { get; set; } = new();
        public string Color { get; set; } = "";
        public string Thickness { get; set; } = "";
        public List<string> Applications { get; set; } = new();
        public string MOQ { get; set; } = "";
        public string ExportDetails { get; set; } = "";
        public bool IsFeatured { get; set; }
        public string Tags { get; set; } = "";
    }
}
