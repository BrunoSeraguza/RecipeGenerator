namespace MyRecipeBookGenerator.Exception.ExceptionsBase;

public class ErrorOnValidatorException : MyRecipeBookException
{
    //readonly só pode ser iniciada no construtor
    private readonly List<string> _errors;

    public ErrorOnValidatorException(List<string> errorsMessage) => _errors = errorsMessage;

    public List<string> GetErrors() => _errors;

}
