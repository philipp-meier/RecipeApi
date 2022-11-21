using MediatR;
using RecipeApi.Commands;
using RecipeApi.Interfaces;

namespace RecipeApi.Handlers;

public class DeleteRecipeCommandHandler : IRequestHandler<DeleteRecipeCommand, bool>
{
    private readonly IDataStore _dataStore;

    public DeleteRecipeCommandHandler(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Task<bool> Handle(DeleteRecipeCommand request, CancellationToken cancellationToken)
    {
        _dataStore.Remove(request.RecipeId);
        return Task.FromResult(true);
    }
}