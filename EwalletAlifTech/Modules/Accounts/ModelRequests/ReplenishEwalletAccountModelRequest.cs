using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace EwalletAlifTech.Modules.Accounts.ModelRequests
{
    public class ReplenishEwalletAccountModelRequest
    {
        [Required(ErrorMessage = "Phone number is required")]
        [JsonProperty("phone_number")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        [JsonProperty("amount")]
        public decimal Amount { get; set; }
    }
}
