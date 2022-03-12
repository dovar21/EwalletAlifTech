using System;

namespace EwalletAlifTech.Modules.Core.Exceptions
{
    public class ExceptionBase : Exception
    {
        public ExceptionBase()
        {

        }
        public ExceptionBase(string message) : base(message)
        {

        }
    }
}
