using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToFahrenheitConverter
    {
        public abstract double Convert(double degrees);
    }

    public class CelsiusToFahrenheitConverter : ToFahrenheitConverter
    {
        public override double Convert(double degrees)
        {
            return degrees * 1.8 + 32;
        }
    }
}
