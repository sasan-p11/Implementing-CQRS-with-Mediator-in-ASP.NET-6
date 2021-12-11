
namespace Application.Exeption;
public class InvalidRequestBodyException : Exception
{
    public string[] Errors { get; set; }
}
