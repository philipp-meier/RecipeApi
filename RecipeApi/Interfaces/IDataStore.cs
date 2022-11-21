using RecipeApi.Models;

namespace RecipeApi.Interfaces;

public interface IDataStore
{
    Recipe Add(RecipeModel model);
    void Update(int recipeId, RecipeModel model);
    void Remove(int recipeId);
    
    Recipe GetRecipe(int recipeId);
    IEnumerable<Recipe> GetRecipes();
}