using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CookingRecipes.Data;
using CookingRecipes.Models;
using HtmlAgilityPack;
using System;
using System.Net.Http;

namespace CookingRecipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly CookingRecipesContext _context;

        public RecipesController(CookingRecipesContext context)
        {
            _context = context;
        }

        public IActionResult Import()
        {
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

            //var timeElement = htmlDocument.DocumentNode.SelectSingleNode("//span[@class='RecipeInfo_cont__2KcUN']");
            //var time = int.Parse(timeElement.InnerText.Trim().Replace("分", ""));

            var ingredientsElement = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='IngredientsList_list__1jDm2']");
            var ingredients = ingredientsElement.InnerText.Trim();

            var directionsElement = htmlDocument.DocumentNode.SelectSingleNode("//ul[@class='CookingProcess_list__2KqPW']");
            var directions = directionsElement.InnerText.Trim();

            var recipe = new Recipe() { Name = name, Description = description, Time = 30, Ingredients = ingredients, Directions = directions};

            return View(recipe);
        }

        // GET: Recipes
        public async Task<IActionResult> Index()
        {
              return _context.Recipe != null ? 
                          View(await _context.Recipe.ToListAsync()) :
                          Problem("Entity set 'CookingRecipesContext.Recipe'  is null.");
        }

        // GET: Recipes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.Include("Reviews")
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // GET: Recipes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RecipeId,Name,Description,Time,Ingredients,Directions")] Recipe recipe)
        {
            ModelState.Remove("Reviews");
            if (ModelState.IsValid)
            {
                _context.Add(recipe);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RecipeId,Name,Description,Time,Ingredients,Directions")] Recipe recipe)
        {
            if (id != recipe.RecipeId)
            {
                return NotFound();
            }

            ModelState.Remove("Reviews");
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(recipe);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecipeExists(recipe.RecipeId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Recipe == null)
            {
                return NotFound();
            }

            var recipe = await _context.Recipe
                .FirstOrDefaultAsync(m => m.RecipeId == id);
            if (recipe == null)
            {
                return NotFound();
            }

            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Recipe == null)
            {
                return Problem("Entity set 'CookingRecipesContext.Recipe'  is null.");
            }
            var recipe = await _context.Recipe.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipe.Remove(recipe);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecipeExists(int id)
        {
          return (_context.Recipe?.Any(e => e.RecipeId == id)).GetValueOrDefault();
        }
    }
}
