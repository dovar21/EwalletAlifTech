using System;

namespace EwalletAlifTech.Modules.DigestAuthentication.Implementation
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
    internal class Clock : IClock
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
