using MediatR;
using RecipeApi.Models;

namespace RecipeApi.Queries;

public class GetRecipeQuery : IRequest<Recipe>
{
    public int RecipeId { get; init; }
}