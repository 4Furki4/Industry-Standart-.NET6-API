using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class ErrorsController : ApiController
{
    [HttpGet("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}
