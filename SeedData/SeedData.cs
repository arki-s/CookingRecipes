using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CookingRecipes.Data;
using System;
using System.Linq;

namespace CookingRecipes.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new CookingRecipesContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<CookingRecipesContext>>()))
        {
            // Look for any Recipes.
            if (context.Recipe.Any())
            {
                return;   // DB has been seeded
            }
            context.Recipe.AddRange(
                new Recipe
                {
                    Name = "Plum and Pecan Muffins",
                    Description = "These plum and pecan muffins are loaded with fruit, so you’ll get a taste of plum in every bite. The pecans and ginger bring additional layers of flavor to the sweet, ripe plums.",
                    Time = 45,
                    Ingredients = "1 teaspoon ground ginger,\n1/2 teaspoon baking soda, \n1 pinch salt, \n1 cup plain Greek yogurt (such as Fage® 2%), \n1/2 cup orange juice, \n2 large eggs, \n1/4 cup melted unsalted butter, \n1 teaspoon vanilla extract, \n2 cups diced pitted plums, \n1/2 cup chopped pecans",
                    Directions = "1. Preheat the oven to 350 degrees F (180 degrees C). Spray a 12-cup standard muffin tin with cooking spray or line with paper liners. \n2. In a large bowl, stir together flour, sugar, baking powder, ginger, baking soda, and salt. \n3. In a separate bowl, whisk yogurt, orange juice, eggs, butter, and vanilla until well combined. \n4. Make a well in the center of dry ingredients; pour yogurt mixture into well and stir just until batter is combined. Gently fold in plums and pecans. Evenly spoon batter into the prepared muffin tin cups. \n5. Bake in the preheated oven until muffins are golden and a toothpick inserted near the center comes out clean, 20 to 25 minutes. \n6. Allow muffins to cool in the pan for 5 minutes, then remove to a wire rack to cool completely."
                },
                new Recipe
                {
                    Name = "Pancake",
                    Description = "In this recipe, pancake means a pan and a cake.",
                    Time = 1,
                    Ingredients = "any pan, \nany cake",
                    Directions = "1. Bring your pan and any cake.  \n2. Put them togather on a table."
                },
                new Recipe
                {
                    Name = "Apple pie",
                    Description = "In this recipe, apple pie means an apple and a pie.",
                    Time = 1,
                    Ingredients = "any apple, \nany pie",
                    Directions = "1. Bring your favorite apple and any pie. \n2. Put them togather on the table."
                },
                new Recipe
                {
                    Name = "TKG",
                    Description = "Japanese traditional and popular food.",
                    Time = 1,
                    Ingredients = "1 cup hot cooked white rice, \n1 large egg, \na dash of soy sauce",
                    Directions = "1. Place rice in a bowl and make a shallow indentation in the center. Break the whole egg into the center. Season with soy sauce. \n2. Stir vigorously with chopsticks to incorporate egg; it should become pale yellow, frothy, and fluffy in texture. Taste and adjust seasonings as necessary."
                },
                new Recipe
                {
                    Name = "CUP NOODLES",
                    Description = "famous and popular food",
                    Time = 3,
                    Ingredients = "1 CUP NOODLES",
                    Directions = "1. Open the cup noodle lid. \n2. Pour boiling water. \n3. Wait 3 minutes."
                },
                new Recipe
                {
                    Name = "Hiyayakko",
                    Description = "Japanese traditional food",
                    Time = 1,
                    Ingredients = "Tohu, \nSoy sauce",
                    Directions = "1. Place a tohu on a plate. \n2. Season with soy sauce."
                },
                new Recipe
                {
                    Name = "Nekomannma",
                    Description = "Japanese traditional food. Ingredients are different between eastern and western Japan.",
                    Time = 1,
                    Ingredients = "1 cup hot cooked white rice, \ndried bonito, \nsoy sauce",
                    Directions = "1. Place rice in a bowl. \n2. Put dried bonito on the rice. \n3. Season with soy sauce."
                },
                new Recipe
                {
                    Name = "Boiled egg",
                    Description = "Super famous food all over the world",
                    Time = 7,
                    Ingredients = "egg",
                    Directions = "1. boil hot water in a pot. \n2. Put an egg in the pot. \n3. Wait (3 minutes: really soft, 4 minutes: runny, 5 minutes: gooey, 6 minutes: softly set, 7 minutes: hard boiled)"
                }
            );
            context.SaveChanges();
        }
    }
}