using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EwalletAlifTech.Modules.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this object obj)
        {
            if (obj == null)
            {
                return "";
            }

            var display = obj.GetType()
                .GetField(obj.ToString()!)?
                .GetCustomAttributes(typeof(DisplayAttribute), false)
                .Cast<DisplayAttribute>()
                .LastOrDefault();

            return display?.GetName() ?? "";
        }
    }
}
