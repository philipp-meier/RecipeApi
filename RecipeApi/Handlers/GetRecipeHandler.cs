using MediatR;
using RecipeApi.Interfaces;
using RecipeApi.Models;
using RecipeApi.Queries;

namespace RecipeApi.Handlers;

public class GetRecipeHandler: IRequestHandler<GetRecipeQuery, Recipe>
{
    private readonly IDataStore _dataStore;

    public GetRecipeHandler(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Task<Recipe> Handle(GetRecipeQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_dataStore.GetRecipe(request.RecipeId));
}