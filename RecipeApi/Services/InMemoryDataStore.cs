using System.Text.Json;
using RecipeApi.Interfaces;
using RecipeApi.Models;

namespace RecipeApi.Services;

public sealed class InMemoryDataStore : IDataStore
{
    private static readonly object AddLock = new();
    private List<Recipe> _recipes { get; }

    public InMemoryDataStore()
    {
        var jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "recipes.json");
        _recipes = JsonSerializer.Deserialize<List<Recipe>>(File.ReadAllText(jsonPath),
            options: new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;
    }

    public Recipe Add(RecipeModel model)
    {
        lock (AddLock)
        {
            var recipe = new Recipe
            {
                Id = _recipes.Max(x => x.Id) + 1,
                Name = model.Name,
                Description = model.Description,
                Ingredients = model.Ingredients
            };
            _recipes.Add(recipe);

            return recipe;
        }
    }

    public void Update(int recipeId, RecipeModel model)
    {
        var recipe = _recipes.Single(x => x.Id == recipeId);
        recipe.Name = model.Name;
        recipe.Description = model.Description;
        recipe.Ingredients = model.Ingredients;
    }

    public void Remove(int recipeId)
    {
        var recipe = _recipes.Single(x => x.Id == recipeId);
        _recipes.Remove(recipe);
    }

    public IEnumerable<Recipe> GetRecipes() => _recipes;
    public Recipe GetRecipe(int recipeId) => _recipes.FirstOrDefault(x => x.Id == recipeId);
}