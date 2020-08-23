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

        public abstract double Convert(double unit);

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

        public override double Convert(double milliliters)
        {
            return milliliters / 100;
        }
    }

    public class LiterToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override double Convert(double liters)
        {
            return liters * 10;
        }
    }

    public class TeaspoonToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override double Convert(double teaspoons)
        {
            return teaspoons * 0.0492892159;
        }
    }

    public class TablespoonToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override double Convert(double tablespoons)
        {
            return tablespoons * 0.147867648;
        }
    }

    public class CupToDeciliterConverter : ToDeciliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override double Convert(double cups)
        {
            return cups * 2.36588237;
        }
    }
}
