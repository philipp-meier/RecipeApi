using MediatR;
using RecipeApi.Commands;
using RecipeApi.Interfaces;
using RecipeApi.Models;

namespace RecipeApi.Handlers;

public class CreateRecipeCommandHandler : IRequestHandler<CreateRecipeCommand, Recipe>
{
    private readonly IDataStore _dataStore;

    public CreateRecipeCommandHandler(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Task<Recipe> Handle(CreateRecipeCommand request, CancellationToken cancellationToken)
        => Task.FromResult(_dataStore.Add(request.RecipeModel));
}