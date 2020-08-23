using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToCelsiusConverter
    {
        public abstract double Convert(double degrees);
    }

    public class FahrenheitToCelsiusConverter : ToCelsiusConverter
    {
        public override double Convert(double degrees)
        {
            return (degrees - 32) / 1.8;
        }
    }
}
