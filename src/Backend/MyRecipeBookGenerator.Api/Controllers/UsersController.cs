using Microsoft.AspNetCore.Mvc;
using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register(RequestRegisterUserAccountJson request)
    {
        return Created();       
    }
}
