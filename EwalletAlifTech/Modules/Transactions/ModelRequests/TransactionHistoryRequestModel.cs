using EwalletAlifTech.Modules.Transactions.Enums;
using Newtonsoft.Json;
using System;

namespace EwalletAlifTech.Modules.Transactions.ModelRequests
{
    public class TransactionHistoryRequestModel
    {
        [JsonProperty("start_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? StartDate { get; set; }

        [JsonProperty("end_date", NullValueHandling = NullValueHandling.Ignore)]
        public DateTime? EndDate { get; set; }

        [JsonProperty("transaction_type", NullValueHandling = NullValueHandling.Ignore)]
        public TransactionType TransactionType { get; set; }
    }
}
