using CookingRecipes.Models;
using System.Collections.Generic;

namespace CookingRecipes.ViewModels
{
    public class ReReViewModel
    {
        public Recipe Recipe { get; set; }
        public List<Review> Review { get; set; }

        public Review Creview { get; set; }

    }
}
