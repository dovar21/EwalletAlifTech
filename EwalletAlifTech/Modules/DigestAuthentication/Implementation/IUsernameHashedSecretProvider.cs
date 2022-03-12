using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.DigestAuthentication.Implementation
{
    public interface IUsernameHashedSecretProvider
    {
        Task<string> GetA1Md5HashForUsernameAsync(string username, string realm);
    }
}