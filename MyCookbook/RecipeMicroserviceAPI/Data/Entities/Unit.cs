using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data.Entities
{
    public class Unit : BaseEntity
    {
        [Required]
        [StringLength(255)]
        public string UnitName { get; set; }

        [Required]
        [StringLength(100)]
        public string UnitAbbreviation { get; set; }

        public UnitType UnitType { get; set; }
    }

    public enum UnitType
    {
        Mass = 1,

        Volume = 2,

        Quantity = 3
    }
}
