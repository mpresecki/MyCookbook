using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToCupConverter : IVolumeConverter
    {
        public static List<ToCupConverter> toCupConverters = new List<ToCupConverter>();

        public ToCupConverter()
        {
            toCupConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_VOLUME_CUP.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToCupConverters()
        {
            _ = new MilliliterToCupConverter();
            _ = new LiterToCupConverter();
            _ = new DeciliterToCupConverter();
            _ = new TeaspoonToCupConverter();
            _ = new TablespoonToCupConverter();
        }
    }

    public class MilliliterToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_MILLILITER.Name;

        public override double Convert(double milliliters)
        {
            return milliliters * 0.00422675284;
        }
    }

    public class LiterToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override double Convert(double liters)
        {
            return liters * 4.22675284;
        }
    }

    public class DeciliterToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override double Convert(double deciliters)
        {
            return deciliters * 0.422675284;
        }
    }

    public class TeaspoonToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override double Convert(double teaspoons)
        {
            return teaspoons * 0.0208333333;
        }
    }

    public class TablespoonToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override double Convert(double tablespoons)
        {
            return tablespoons * 0.0625;
        }
    }
}
