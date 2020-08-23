using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToFahrenheitConverter
    {
        public abstract decimal Convert(decimal degrees);
    }

    public class CelsiusToFahrenheitConverter : ToFahrenheitConverter
    {
        public override decimal Convert(decimal degrees)
        {
            return (degrees * (decimal)1.8) + 32;
        }
    }
}
