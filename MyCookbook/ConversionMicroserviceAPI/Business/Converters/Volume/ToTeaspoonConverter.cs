using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToTeaspoonConverter : IVolumeConverter
    {
        public static List<ToTeaspoonConverter> toTeaspoonConverters = new List<ToTeaspoonConverter>();

        public ToTeaspoonConverter()
        {
            toTeaspoonConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_VOLUME_TEASPOON.Name;

        public abstract string UnitFrom { get; }

        public abstract decimal Convert(decimal unit);

        public static void CreateToTeaspoonConverters()
        {
            _ = new MilliliterToTeaspoonConverter();
            _ = new LiterToTeaspoonConverter();
            _ = new DeciliterToTeaspoonConverter();
            _ = new TablespoonToTeaspoonConverter();
            _ = new CupToTeaspoonConverter();
        }
    }

    public class MilliliterToTeaspoonConverter : ToTeaspoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_MILLILITER.Name;

        public override decimal Convert(decimal milliliters)
        {
            return milliliters * (decimal)0.202884136;
        }
    }

    public class LiterToTeaspoonConverter : ToTeaspoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_LITER.Name;

        public override decimal Convert(decimal liters)
        {
            return liters * (decimal)202.884136;
        }
    }

    public class DeciliterToTeaspoonConverter : ToTeaspoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_DECILITER.Name;

        public override decimal Convert(decimal deciliters)
        {
            return deciliters * (decimal)20.2884136;
        }
    }

    public class TablespoonToTeaspoonConverter : ToTeaspoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_TABLESPOON.Name;

        public override decimal Convert(decimal tablespoons)
        {
            return tablespoons * 3;
        }
    }

    public class CupToTeaspoonConverter : ToTeaspoonConverter
    {
        public override string UnitFrom => Constants.UNIT_VOLUME_CUP.Name;

        public override decimal Convert(decimal cups)
        {
            return cups * 48;
        }
    }
}
