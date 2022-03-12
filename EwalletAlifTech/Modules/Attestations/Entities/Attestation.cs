using EwalletAlifTech.Modules.Core.Entities;
using EwalletAlifTech.Modules.Users.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EwalletAlifTech.Modules.Users.Modules.Attestations.Entities
{
    public class Attestation : EntityBase
    {
        public string Code { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public List<User> Users { get; set; } 
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
