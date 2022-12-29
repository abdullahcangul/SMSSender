namespace SMSSender.Lib.Exceptions;

public class EmptyOrNullException:Exception
{
    public EmptyOrNullException()
    {
        
    }
    public EmptyOrNullException(string name):base($"{name} can not be empty or null")
    {
        
    }
}