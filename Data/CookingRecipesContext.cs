using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CookingRecipes.Models;

namespace CookingRecipes.Data
{
    public class CookingRecipesContext : DbContext
    {
        public CookingRecipesContext (DbContextOptions<CookingRecipesContext> options)
            : base(options)
        {
        }

        public DbSet<CookingRecipes.Models.Recipe> Recipe { get; set; } = default!;
    }
}
