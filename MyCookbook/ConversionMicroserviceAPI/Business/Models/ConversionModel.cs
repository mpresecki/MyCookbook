using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Models
{
    public class ConversionModel
    {
        public UnitModel UnitFrom { get; set; }

        public decimal QuantityFrom { get; set; }

        public UnitModel UnitTo { get; set; }

        public decimal QuantityTo { get; set; }
    }
}
