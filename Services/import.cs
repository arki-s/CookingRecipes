using CookingRecipes.Models;
using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace CookingRecipes.Services
{
    public class Import
    {
       //使い方模索中
        public Recipe importRecipe() {

            string[] pages = new string[] {
            "https://oceans-nadia.com/user/792202/recipe/461965",
            "https://oceans-nadia.com/user/40170/recipe/364594",
            "https://oceans-nadia.com/user/236306/recipe/468045",
            "https://oceans-nadia.com/user/484627/recipe/466095",
            "https://oceans-nadia.com/user/593208/recipe/467747",
            "https://oceans-nadia.com/user/579331/recipe/455279",
            "https://oceans-nadia.com/user/236306/recipe/454363",
            "https://oceans-nadia.com/user/236306/recipe/457121",
            "https://oceans-nadia.com/user/45109/recipe/469555",
            "https://oceans-nadia.com/user/882109/recipe/460726"
            };
            Random random = new Random();
            int rnd = random.Next(pages.Length);

            String url = pages[rnd];
            var httpClient = new HttpClient();
            var html = httpClient.GetStringAsync(url).Result;
            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);

            var nameElement = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='RecipeTitle_RecipeTitle__X3egx']");
            var name = nameElement.InnerText.Trim();

            var descriptionElement = htmlDocument.DocumentNode.SelectSingleNode("//div[@class='RecipeDesc_box__hYIxT']");
            var description = descriptionElement.InnerText.Trim();

            var ingredientsElement = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='IngredientsList_list__1jDm2']");
            var ingredients = ingredientsElement.InnerText.Trim();

            var directionsElement = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='CookingProcess_list__2KqPW']");
            var directions = directionsElement.InnerText.Trim();

            var recipe = new Recipe() { Name = name, Description = description, Time = 30, Ingredients = ingredients, Directions = directions };

            return recipe;
        }
    }
}
