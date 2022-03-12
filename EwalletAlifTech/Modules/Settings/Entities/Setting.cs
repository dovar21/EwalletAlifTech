using System;
using EwalletAlifTech.Modules.Core.Entities;

namespace EwalletAlifTech.Modules.Settings.Entities
{
    public class Setting:EntityBase
    {
        public string Key { get; set; }

        public string Value { get; set; }

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
