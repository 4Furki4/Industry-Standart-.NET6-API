using BuberBreakfast.BuberBreakfast.Models;
using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.ServiceErrors;
using BuberBreakfast.Services;
using BuberBreakfast.Services.BreakfastService;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController
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
                DateTime.Now,
                request.Savory,
                request.Sweet
            );

        //TODO: save breakfast to database.
        ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

        return createBreakfastResult.Match(
            created=> CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors)
        ); // Get the data from our system and convert it to api definition.
    }
    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
        return getBreakfastResult.Match(
            breakfast =>Ok (MapBreakfastResponse(breakfast)),
            errors => Problem(errors)
        );
        // if (getBreakfastResult.IsError && getBreakfastResult.FirstError == Errors.Breakfast.NotFound)
        // {
        //     return NotFound();
        // }
        // var breakfast = getBreakfastResult.Value;
        // BreakfastResponse response = MapBreakfastResponse(breakfast);
        // return Ok(response);
    }
    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        var breakfast = new Breakfast(
            id,
            request.Name,
            request.Description,
            request.StartDateTime,
            request.EndDateTime,
            DateTime.Now,
            request.Savory,
            request.Sweet
        );
        ErrorOr<UpsertedBreakfast> upsertedBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);
        //TODO: return 201 if a new breakfast was created.
        return upsertedBreakfastResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast): NoContent(),
            errors => Problem(errors));
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deletedBreakfastResult = _breakfastService.DeleteBreakfast(id);
        deletedBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
        return NoContent();
    }
    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
                    breakfast.Id,
                    breakfast.Name,
                    breakfast.Definition,
                    breakfast.StartDateTime,
                    breakfast.EndDateTime,
                    breakfast.LastModifiedDateTime,
                    breakfast.Savory,
                    breakfast.Sweet
                );
    }
    private IActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
                    actionName: nameof(GetBreakfast), //the action in which the client can retrive the resource
                    new { id = breakfast.Id }, //parameters of given action method
                    value: MapBreakfastResponse(breakfast));
    }
}