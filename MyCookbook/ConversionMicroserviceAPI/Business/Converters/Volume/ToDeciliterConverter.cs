using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToDeciliterConverter : IVolumeConverter
    {
        public static List<ToDeciliterConverter> toDeciliterConverters = new List<ToDeciliterConverter>();

        public ToDeciliterConverter()
        {
            toDeciliterConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_VOLUME_DECILITER.Name;

        public abstract string UnitFrom { get; }

        public abstract decimal Convert(decimal unit);

        public static void CreateToDecilitersConverters()
        {
            _ = new MilliliterToDeciliterConverter();
            _ = new LiterToDeciliterConverter();
            _ = new TeaspoonToDeciliterConverter();
            _ = new TablespoonToDeciliterConverter();
            _ = new CupToDeciliterConverter();
        }
    }

    public class MilliliterToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_MILLILITER.Name;

        public override decimal Convert(decimal milliliters)
        {
            return milliliters / 100;
        }
    }

    public class LiterToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override decimal Convert(decimal liters)
        {
            return liters * 10;
        }
    }

    public class TeaspoonToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override decimal Convert(decimal teaspoons)
        {
            return teaspoons * (decimal)0.0492892159;
        }
    }

    public class TablespoonToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override decimal Convert(decimal tablespoons)
        {
            return tablespoons * (decimal)0.147867648;
        }
    }

    public class CupToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override decimal Convert(decimal cups)
        {
            return cups * (decimal)2.36588237;
        }
    }
}
