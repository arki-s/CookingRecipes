namespace CookingRecipes.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int Time { get; set; }
        public string Ingredients { get; set; }
        public string Directions { get; set; }
    }
}
