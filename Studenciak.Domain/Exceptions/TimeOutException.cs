namespace Domain.Exceptions;

public class TimeOutException:Exception
{
    public TimeOutException(string message) : base(message)
    {
        
    }
}