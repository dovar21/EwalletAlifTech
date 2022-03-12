using System;

namespace EwalletAlifTech.Modules.Core.Exceptions
{
    public class ResourceNotFoundException: Exception
    {

        public ResourceNotFoundException()
        {

        }

        public ResourceNotFoundException(string message) : base(message)
        {

        }
    }
}
