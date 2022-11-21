using System.ComponentModel.DataAnnotations;

namespace RecipeApi.Models;

public class Recipe
{
    public int Id { get; init; }
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
}

public class RecipeModel
{
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public List<RecipeIngredient> Ingredients { get; set; }
}