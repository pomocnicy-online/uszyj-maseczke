using System;
using UszyjMaseczke.Domain.Exceptions;

namespace UszyjMaseczke.Application.Exceptions
{
    public class NotFoundException : UszyjMaseczkeExceptionBase
    {
        public NotFoundException() : base()
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}