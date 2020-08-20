using RecipeMicroserviceAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Business.Models
{
    public class UnitModel
    {
        public string UnitName { get; set; }

        public string UnitAbbreviation { get; set; }

        public UnitType UnitType { get; set; }
    }
}
