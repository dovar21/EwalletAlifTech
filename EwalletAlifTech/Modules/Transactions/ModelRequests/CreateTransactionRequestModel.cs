using EwalletAlifTech.Modules.Users.Entities;

namespace EwalletAlifTech.Modules.Transactions.ModelRequests
{
    public class CreateTransactionRequestModel
    {
        public User FromUser { get; set; }
        public string PhoneNumber { get; set; }
        public decimal Amount { get; set; }
    }
}
