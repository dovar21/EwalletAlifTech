using Newtonsoft.Json;

namespace EwalletAlifTech.Modules.Accounts.ModelResponses
{
    public class CheckEwalletAccountBalanceModelResponse
    {
        public string Number { get; set; }
        public decimal Balance { get; set; }
        [JsonProperty("balance_limit")]
        public decimal BalanceLimit { get; set; }
    }

}
