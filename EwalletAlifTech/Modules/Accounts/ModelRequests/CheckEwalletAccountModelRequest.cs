using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EwalletAlifTech.Modules.Accounts.ModelRequests
{
    public class CheckEwalletAccountModelRequest
    {
        [Required(ErrorMessage = "Phone number is required")]
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
    }
}
