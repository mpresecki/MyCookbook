using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToCelsiusConverter
    {
        public abstract decimal Convert(decimal degrees);
    }

    public class FahrenheitToCelsiusConverter : ToCelsiusConverter
    {
        public override decimal Convert(decimal degrees)
        {
            return ((degrees - 32) / (decimal)1.8);
        }
    }
}
