using MediatR;
using RecipeApi.Interfaces;
using RecipeApi.Models;
using RecipeApi.Queries;

namespace RecipeApi.Handlers;

public class GetRecipesHandler: IRequestHandler<GetRecipesQuery, IEnumerable<Recipe>>
{
    private readonly IDataStore _dataStore;

    public GetRecipesHandler(IDataStore dataStore)
    {
        _dataStore = dataStore;
    }
    
    public Task<IEnumerable<Recipe>> Handle(GetRecipesQuery request, CancellationToken cancellationToken)
        => Task.FromResult(_dataStore.GetRecipes());
}