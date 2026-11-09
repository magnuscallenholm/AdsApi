using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace AdsApi.Models
{
    public class Ad
    {
        public int Id { get; set; }       
        public DateTime CreateDate { get; set; }

        [Required(ErrorMessage = "Please enter a title.")]
        [StringLength(100)]
        public string Title { get; set; } = "";

        [Required(ErrorMessage = "Please enter a description.")]
        [StringLength(2000)]
        public string Description { get; set; } = "";
       
        [Range(typeof(decimal), "0", "1000000",
            ErrorMessage = "Price must be between 0 and 1 000 000.")]
        [Precision(18, 2)]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Please enter a category.")]
        [StringLength(50)]
        public string Category { get; set; } = "";

        [Required(ErrorMessage = "Please enter an email.")]
        [EmailAddress(ErrorMessage = "Please enter a valid email.")]
        [StringLength(100)]
        public string Email { get; set; } = "";
        
        [StringLength(25)]
        [Display(Name = "Phone number")]
        [RegularExpression(@"^[0-9 \-]+$",
            ErrorMessage = "Only digits, spaces and hyphens are allowed.")]
        public string? Telephone { get; set; }
    }
}