using System;

namespace UszyjMaseczke.Domain.Exceptions
{
    public abstract class UszyjMaseczkeExceptionBase : Exception
    {
        public UszyjMaseczkeExceptionBase()
        {
        }

        public UszyjMaseczkeExceptionBase(string message)
            : base(message)
        {
        }

        public UszyjMaseczkeExceptionBase(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}