using System.Runtime.Serialization;

namespace RessourcesHumaines.Domain.Exceptions;

public class MatriculeDejaExistantException : Exception
{
    public MatriculeDejaExistantException() : base("Matricule deja existant")
    {
    }

    protected MatriculeDejaExistantException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }

    public MatriculeDejaExistantException(string? message) : base(message)
    {
    }

    public MatriculeDejaExistantException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}