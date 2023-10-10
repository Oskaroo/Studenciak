namespace Application.Common.Exceptions;

public class TimeOutException:Exception
{
    public TimeOutException(string message) : base(message)
    {
        
    }
}