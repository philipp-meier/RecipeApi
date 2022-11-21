using MediatR;
using RecipeApi.Models;

namespace RecipeApi.Commands;

public class UpdateRecipeCommand : IRequest<bool>
{
    public int RecipeId { get; init; }
    public RecipeModel RecipeModel { get; init; }
}