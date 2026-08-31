using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MyRecipeBookGenerator.Communication.Response;

public class ResponseErrorJson
{
    public List<string> Errors { get; private set; }

    public ResponseErrorJson(List<string> errosMessage)
    {
        Errors = errosMessage;
    }

    public ResponseErrorJson(string message)
    {
        Errors = new List<string>();

        Errors.Add(message);       
    }
}
