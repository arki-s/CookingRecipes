using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingRecipes.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }
        public string? Commnet { get; set; }

        [Display(Name = "Recipe")]

        [ForeignKey("Id")]
        public Recipe Recipe { get; set; }
    }
}
