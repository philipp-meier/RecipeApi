using MediatR;
using RecipeApi.Models;

namespace RecipeApi.Queries;

public class GetRecipesQuery : IRequest<IEnumerable<Recipe>>
{
}