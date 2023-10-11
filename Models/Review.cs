using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CookingRecipes.Models
{
    public class Review
    {
        public int ReviewId { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(1,5)]
        public int Rating { get; set; }

        [MinLength(5)]
        [MaxLength(280)]
        public string? Comment { get; set; }

        [Display(Name = "Recipe")]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
