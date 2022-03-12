using System;

namespace EwalletAlifTech.Modules.Core.Exceptions
{
    public class AccessForbiddenException : Exception
    {
        public AccessForbiddenException()
        {

        }

        public AccessForbiddenException(string message):base(message)
        {

        }
    }
}
