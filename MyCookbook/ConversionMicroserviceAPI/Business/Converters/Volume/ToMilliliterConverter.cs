using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToMilliliterConverter : IVolumeConverter
    {
        public static List<ToMilliliterConverter> toMilliliterConverters = new List<ToMilliliterConverter>();

        public ToMilliliterConverter()
        {
            toMilliliterConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_VOLUME_MILLILITER.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToMilliliterConverters()
        {
            _ = new LiterToMilliliterConverter();
            _ = new DeciliterToMilliLiterConverter();
            _ = new TeaspoonToMilliLiterConverter();
            _ = new TablespoonToMilliLiterConverter();
            _ = new CupToMilliLiterConverter();
        }
    }

    public class LiterToMilliliterConverter : ToMilliliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override double Convert(double liters)
        {
            return liters * 1000;
        }
    }

    public class DeciliterToMilliLiterConverter : ToMilliliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override double Convert(double deciliters)
        {
            return deciliters * 100;
        }
    }

    public class TeaspoonToMilliLiterConverter : ToMilliliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override double Convert(double teaspoons)
        {
            return teaspoons * 4.92892159;
        }
    }

    public class TablespoonToMilliLiterConverter : ToMilliliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override double Convert(double tablespoons)
        {
            return tablespoons * 14.7867648;
        }
    }

    public class CupToMilliLiterConverter : ToMilliliterConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override double Convert(double cups)
        {
            return cups * 236.588237;
        }
    }
}
