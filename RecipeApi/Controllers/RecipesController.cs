using System.Net.Mime;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecipeApi.Commands;
using RecipeApi.Models;
using RecipeApi.Queries;

namespace RecipeApi.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RecipesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(IEnumerable<Recipe>), StatusCodes.Status200OK)]
    public async Task<IEnumerable<Recipe>> Get()
        => await _mediator.Send(new GetRecipesQuery());

    [HttpPost("add")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status201Created)]
    public async Task<IActionResult> Add([FromBody] RecipeModel recipeModel)
    {
        var result = await _mediator.Send(new CreateRecipeCommand { RecipeModel = recipeModel });
        var location = Url.Action(nameof(Get), new { recipeId = result.Id }) ?? $"/{result.Id}";
        return Created(location, result);
    }
    
    [HttpGet("{recipeId:int}")]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(Recipe), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int recipeId)
    {
        var recipe = await _mediator.Send(new GetRecipeQuery { RecipeId = recipeId });
        if (recipe == null)
            return NotFound();
        
        return Ok(recipe);
    }
    
    [HttpPut("{recipeId:int}")]
    [Consumes(MediaTypeNames.Application.Json)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Update([FromBody] RecipeModel recipeModel, int recipeId)
    {
        try
        {
            await _mediator.Send(new UpdateRecipeCommand { RecipeId = recipeId, RecipeModel = recipeModel });
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
    
    [HttpDelete("{recipeId:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Delete(int recipeId)
    {
        try
        {
            await _mediator.Send(new DeleteRecipeCommand { RecipeId = recipeId });
            return Ok();
        }
        catch
        {
            return BadRequest();
        }
    }
}