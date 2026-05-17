using System.ComponentModel.DataAnnotations;

namespace JaipurMeniral.Models
{
    public class InquiryModel
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = "";

        [Required(ErrorMessage = "Phone is required")]
        public string Phone { get; set; } = "";

        [Required(ErrorMessage = "Country is required")]
        public string Country { get; set; } = "";

        public string ProductName { get; set; } = "";

        [Required(ErrorMessage = "Message is required")]
        public string Message { get; set; } = "";
    }
}
