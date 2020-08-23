using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToLiterConverter : IVolumeConverter
    {
        public static List<ToLiterConverter> toLiterConverters = new List<ToLiterConverter>();

        public ToLiterConverter()
        {
            toLiterConverters.Add(this);
        }

        public string UnitTo => Constants.UNIT_VOLUME_LITER.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToLiterConverters()
        {
            _ = new MilliliterToLiterConverter();
            _ = new DeciliterToLiterConverter();
            _ = new TeaspoonToLiterConverter();
            _ = new TablespoonToLiterConverter();
            _ = new CupToLiterConverter();
        }
    }

    public class MilliliterToLiterConverter : ToLiterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_MILLILITER.Name;

        public override double Convert(double milliliters)
        {
            return milliliters / 1000;
        }
    }

    public class DeciliterToLiterConverter : ToLiterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override double Convert(double deciliters)
        {
            return deciliters / 10;
        }
    }

    public class TeaspoonToLiterConverter : ToLiterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override double Convert(double teaspoons)
        {
            return teaspoons * 0.00492892159;
        }
    }

    public class TablespoonToLiterConverter : ToLiterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override double Convert(double tablespoons)
        {
            return tablespoons * 0.0147867648;
        }
    }

    public class CupToLiterConverter : ToLiterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override double Convert(double cups)
        {
            return cups * 0.236588237;
        }
    }
}
