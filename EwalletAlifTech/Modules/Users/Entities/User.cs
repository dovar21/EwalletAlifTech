using System;
using System.Collections.Generic;
using EwalletAlifTech.Modules.Core.Entities;
using EwalletAlifTech.Modules.Users.Modules.Attestations.Entities;
using EwalletAlifTech.Modules.Accounts.Entities;
using EwalletAlifTech.Modules.Transactions.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace EwalletAlifTech.Modules.Users.Entities
{
    public class User : EntityBase
    {
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Hash { get; set; }
        public string FullName { get; set; }
        public Guid AttestationId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsActive { get; set; }
        [NotMapped]
        public List<Account> Accounts { get; set; }
        [NotMapped]
        public List<Transaction> Transactions { get; set; }
        public Attestation Attestation { get; set; }
    }
}
