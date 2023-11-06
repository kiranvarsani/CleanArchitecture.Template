using System.Runtime.InteropServices.JavaScript;
using Domain.Primitives;

namespace Domain.Shared;

public sealed class Error : ValueObject
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Error"/> class.
    /// </summary>
    /// <param name="code">The error code.</param>
    /// <param name="message">The error message.</param>
    public Error(string code, string message)
    {
        Code = code;
        Message = message;
    }

    /// <summary>
    /// Gets the error code.
    /// </summary>
    public string Code { get; }
    
    /// <summary>
    /// Gets the error message.
    /// </summary>
    public string Message { get; }

    public static implicit operator string(Error error) => error?.Code ?? string.Empty;
    
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Code;
        yield return Message;
    }
    
    public static readonly Error None = new(string.Empty, string.Empty);
    public static readonly Error NullValue = new("Error.NullValue", "The specified result value is null.");
}