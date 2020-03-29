using System;

namespace UszyjMaseczke.Domain.Exceptions
{
    public class ValidationException : UszyjMaseczkeExceptionBase
    {
        public ValidationException() : base()
        {
        }

        public ValidationException(string message)
            : base(message)
        {
        }

        public ValidationException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}