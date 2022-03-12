using EwalletAlifTech.Modules.DigestAuthentication.Implementation;
using EwalletAlifTech.Modules.Users.Repositories;
using System.Threading.Tasks;

namespace EwalletAlifTech.Modules.DigestAuthentication.Providers
{
    internal class UsernameHashedSecretProvider : IUsernameHashedSecretProvider
    {
        private readonly IUserRepository _userRepository;
        public UsernameHashedSecretProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> GetA1Md5HashForUsernameAsync(string username, string realm) {

            //Get user by username
            var user = await _userRepository.FindByUsernameAsync(username);

            if (user != null && realm == "ew-realm")
            {
                //Hash
                string hash = Implementation.DigestAuthentication.ComputeA1Md5Hash(username, "ew-realm", user.Password);
                
                return hash;
            }

            // User not found
            return null;
        }
    }
}