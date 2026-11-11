namespace MyRecipeBookGenerator.Communication.Response;

public class ResponseRegisterUserJson
{
    public string Name { get; set; } = string.Empty;
    public ResponseTokenJson Token { get; set; } = default!;
}
