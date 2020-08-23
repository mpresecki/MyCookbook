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

        public abstract decimal Convert(decimal unit);

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

        public override decimal Convert(decimal milliliters)
        {
            return milliliters * (decimal)0.0676280454;
        }
    }

    public class LiterToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override decimal Convert(decimal liters)
        {
            return liters * (decimal)67.6280454;
        }
    }

    public class DeciliterToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override decimal Convert(decimal deciliters)
        {
            return deciliters * (decimal)6.76280454;
        }
    }

    public class TeaspoonToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TEASPOON.Name;

        public override decimal Convert(decimal teaspoons)
        {
            return teaspoons * (decimal)0.333333333;
        }
    }

    public class CupToTablespoonConverter : ToTablespoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override decimal Convert(decimal cups)
        {
            return cups * 16;
        }
    }
}
