using Microsoft.AspNetCore.Mvc;
using MyRecipeBookGenerator.Application.UseCases.User.Register;
using MyRecipeBookGenerator.Communication.Request;
using MyRecipeBookGenerator.Communication.Response;

namespace MyRecipeBookGenerator.Api.Controllers;

[Route("[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(ResponseRegisterUserJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Register([FromBody] RequestRegisterUserAccountJson request, [FromServices] IRegisterUserAccountUseCase userCase)
    {
        var result = await userCase.Execute(request);

        return Created(string.Empty, result);
    }
}
