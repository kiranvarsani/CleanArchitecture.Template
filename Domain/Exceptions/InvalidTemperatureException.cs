namespace Domain.Exceptions;

public sealed class InvalidTemperatureException : DomainException
{
    public InvalidTemperatureException(string message) : base(message)
    {
    }
}