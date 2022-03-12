namespace EwalletAlifTech.Modules.DigestAuthentication.Implementation
{
    public static class DigestAuthentication
    {
        public static string ComputeA1Md5Hash(string username, string realm, string secret) {
            var a1 = $"{username}:{realm}:{secret}";
            return a1.ToMD5Hash();
        }
    }
}