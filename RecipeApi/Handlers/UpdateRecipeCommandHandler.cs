using MediatR;
using RecipeApi.Commands;
using RecipeApi.Interfaces;

namespace RecipeApi.Handlers;

public class UpdateRecipeCommandHandler : IRequestHandler<UpdateRecipeCommand, bool>
{
    private readonly IDataStore _dataStore;

    public UpdateRecipeCommandHandler(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Task<bool> Handle(UpdateRecipeCommand request, CancellationToken cancellationToken)
    {
        _dataStore.Update(request.RecipeId, request.RecipeModel);
        return Task.FromResult(true);
    }
}