using System.ComponentModel.DataAnnotations;

namespace CoreAndFood.Models
{
    public class Category
    {
        public int CategoryID { get; set; }
        [Required(ErrorMessage = "This area cannot be empty")]
        [StringLength(20, ErrorMessage = "Please enter 3-20 character in field",MinimumLength = 3) ]
        public string CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public bool Status { get; set; }
        List<Food> Foods { get; set; }
    }
}
