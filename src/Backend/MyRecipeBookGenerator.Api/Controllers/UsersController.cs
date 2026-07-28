using Microsoft.AspNetCore.Mvc;
using MyRecipeBookGenerator.Application.UseCases.User.Register;
using MyRecipeBookGenerator.Communication.Request;

namespace MyRecipeBookGenerator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public IActionResult Register([FromBody]RequestRegisterUserAccountJson request)
    {
        var useCase = new RegisterUserAccountUseCase();
        useCase.Execute(request);

        return Created();       
    }
}
