using Microsoft.AspNetCore.Mvc;
using MyRecipeBookGenerator.Application.UseCases.User.Register;
using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Exception.ExceptionsBase;

namespace MyRecipeBookGenerator.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase registerUserAccountUseCase)
    {
        await registerUserAccountUseCase.Execute(request);

        return Created();
    }
}
