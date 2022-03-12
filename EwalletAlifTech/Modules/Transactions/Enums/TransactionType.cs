using System.ComponentModel.DataAnnotations;

namespace EwalletAlifTech.Modules.Transactions.Enums
{
    public enum TransactionType
    {
        [Display(Name = "Replenishment")]
        Replenishment = 0,

        [Display(Name = "Withdrawal")]
        Withdrawal = 1,
    }
}
