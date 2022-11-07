using BuberBreakfast.BuberBreakfast.Models;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Services.BreakfastService;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.BuberBreakfast.Controllers;
[ApiController]
[Route("[controller]")] //gets controller name without controller suffix.
public class BreakfastsController : ControllerBase
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService IBreakfastService)
    {
        _breakfastService = IBreakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
    // get in the data the language our application speak.
    var breakfast = new Breakfast(  
            Guid.NewGuid(),
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.UtcNow,
            request.Savory,
            request.Sweet
        );

        //TODO: save breakfast to database.
        _breakfastService.CreateBreakfast(breakfast);
        // Get the data from our system and convert it to api definition.
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Definition,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return CreatedAtAction(
            actionName: nameof(GetBreakfast), //the action in which the client can retrive the resource
            new {id = breakfast.Id}, //parameters of given action method
            value: response);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Breakfast breakfast = _breakfastService.GetBreakfast(id);
        var response = new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Definition,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet
        );
        return Ok(response);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        return Ok(request);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        return Ok(id);
    }
}