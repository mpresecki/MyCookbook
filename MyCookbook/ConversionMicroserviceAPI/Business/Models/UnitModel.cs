using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Models
{
    public class UnitModel
    {
        public long Id { get; set; }

        public string UnitName { get; set; }

        public string UnitAbbreviation { get; set; }

        public UnitType UnitType { get; set; }
    }

    public enum UnitType
    {
        Mass = 1,

        Volume = 2,

        Quantity = 3,

        Temperature = 4
    }
}
