using System.ComponentModel.DataAnnotations;

namespace CookingRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        
        [DataType(DataType.Text)]
        [Required]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        public string? Description { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required]
        [Range(0, 1000)]
        public int Time { get; set; }


        [DataType(DataType.Text)]
        [Required]
        public string Ingredients { get; set; }

        [DataType(DataType.Text)]
        [Required]
        public string Directions { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}
