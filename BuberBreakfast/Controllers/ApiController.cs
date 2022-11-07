using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

[ApiController]
[Route("[controller]")] //gets controller name without controller suffix.
public class ApiController : ControllerBase 
{
    protected IActionResult Problem(List<Error> errors) 
    {
        var firstError = errors[0];

        var statusCode = firstError.Type switch
        {
            ErrorType.NotFound =>  StatusCodes.Status404NotFound,
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.Conflict => StatusCodes.Status500InternalServerError
        };
        return Problem(statusCode: statusCode, title: firstError.Description);
    }
}
