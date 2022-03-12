using System;
using System.IO;
using System.Linq;

namespace EwalletAlifTech.Modules.Core.Helpers
{
    public abstract class BootstrapBase
    {
        protected abstract string GetCurrentNamespace();

        public string GetPathSettings(string filenameSettings = "settings.json")
        {
            string currentNamespace =
                this.GetCurrentNamespace();

            string[] fullPath = currentNamespace.Split(".");

            var relativePath = fullPath.Where(p => p != fullPath[0]).ToArray();

            Array.Resize(ref relativePath, relativePath.Length + 1);
            relativePath[relativePath.Length - 1] = filenameSettings;
            return Path.Combine(relativePath);
        }
    }
}
