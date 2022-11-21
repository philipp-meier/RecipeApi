using MediatR;

namespace RecipeApi.Commands;

public class DeleteRecipeCommand : IRequest<bool>
{
    public int RecipeId { get; init; }
}