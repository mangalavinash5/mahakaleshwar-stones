namespace JaipurMeniral.Models
{
    public class Project
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Slug { get; set; } = "";
        public string Description { get; set; } = "";
        public string Image { get; set; } = "";
        public string MaterialUsed { get; set; } = "";
        public string Location { get; set; } = "";
        public string Category { get; set; } = "";
        public int Year { get; set; }
    }
}
