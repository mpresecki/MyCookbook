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

        public abstract decimal Convert(decimal unit);

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

        public override decimal Convert(decimal milliliters)
        {
            return milliliters * (decimal)0.00422675284;
        }
    }

    public class LiterToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override decimal Convert(decimal liters)
        {
            return liters * (decimal)4.22675284;
        }
    }

    public class DeciliterToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override decimal Convert(decimal deciliters)
        {
            return deciliters * (decimal)0.422675284;
        }
    }

    public class TeaspoonToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override decimal Convert(decimal teaspoons)
        {
            return teaspoons * (decimal)0.0208333333;
        }
    }

    public class TablespoonToCupConverter : ToCupConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override decimal Convert(decimal tablespoons)
        {
            return tablespoons * (decimal)0.0625;
        }
    }
}
