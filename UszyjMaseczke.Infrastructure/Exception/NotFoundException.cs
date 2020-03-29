using UszyjMaseczke.Domain.Exceptions;

namespace UszyjMaseczke.Infrastructure.Exception
{
    public class NotFoundException : UszyjMaseczkeExceptionBase
    {
        public NotFoundException()
        {
        }

        public NotFoundException(string message) : base(message)
        {
        }

        public NotFoundException(string message, System.Exception inner) : base(message, inner)
        {
        }
    }
}