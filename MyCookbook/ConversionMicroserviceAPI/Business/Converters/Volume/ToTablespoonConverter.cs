using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToTablespoonConverter : IVolumeConverter
    {
        public static List<ToTablespoonConverter> toTablespoonConverters = new List<ToTablespoonConverter>();

        public ToTablespoonConverter()
        {
            toTablespoonConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_VOLUME_TABLESPOON.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToTablespoonConverters()
        {
            _ = new MilliliterToTablespoonConverter();
            _ = new LiterToTablespoonConverter();
            _ = new DeciliterToTablespoonConverter();
            _ = new TeaspoonToTablespoonConverter();
            _ = new CupToTablespoonConverter();
        }
    }

    public class MilliliterToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_MILLILITER.Name;

        public override double Convert(double milliliters)
        {
            return milliliters * 0.0676280454;
        }
    }

    public class LiterToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override double Convert(double liters)
        {
            return liters * 67.6280454;
        }
    }

    public class DeciliterToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override double Convert(double deciliters)
        {
            return deciliters * 6.76280454;
        }
    }

    public class TeaspoonToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override double Convert(double teaspoons)
        {
            return teaspoons * 0.333333333;
        }
    }

    public class CupToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override double Convert(double cups)
        {
            return cups * 16;
        }
    }
}
