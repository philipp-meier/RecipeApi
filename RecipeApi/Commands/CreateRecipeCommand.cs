using MediatR;
using RecipeApi.Models;

namespace RecipeApi.Commands;

public class CreateRecipeCommand : IRequest<Recipe>
{
    public RecipeModel RecipeModel { get; init; }
}