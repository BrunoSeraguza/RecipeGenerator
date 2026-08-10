namespace MyRecipeBookGenerator.Exception.ExceptionsBase;

public class ErrorOnValidatorException : MyRecipeBookException
{
    //readonly só pode ser iniciada no construtor
    private readonly List<string> _message;

    public ErrorOnValidatorException(List<string> errorsMessage) => _message = errorsMessage;

}
