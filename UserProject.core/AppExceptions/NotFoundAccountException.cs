namespace UserProject.Core.AppExceptions;

[Serializable]
public class NotFoundAccountException : Exception
{
    public NotFoundAccountException()
    {
    }

    public NotFoundAccountException(string? message) : base(message)
    {
    }

    public NotFoundAccountException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}