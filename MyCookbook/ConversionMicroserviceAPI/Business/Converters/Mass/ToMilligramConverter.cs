using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToMilligramConverter : IMassConverter
    {
        public static List<ToMilligramConverter> toMilligramConverters = new List<ToMilligramConverter>();

        public ToMilligramConverter()
        {
            toMilligramConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_MASS_MILLIGRAM.Name;

        public abstract string UnitFrom { get; }

        public abstract decimal Convert(decimal unit);

        public static void CreateToMilligramConverters()
        {
            _ = new GramToMilligramConverter();
            _ = new DecagramToMilligramConverter();
            _ = new KilogramToMilligramConverter();
            _ = new PoundToMilligramConverter();
        }
    }

    public class GramToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_GRAM.Name;

        public override decimal Convert(decimal grams)
        {
            return grams * 1000;
        }
    }

    public class KilogramToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_KILOGRAM.Name;

        public override decimal Convert(decimal kilograms)
        {
            return kilograms * 1000000;
        }
    }

    public class DecagramToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_DECAGRAM.Name;

        public override decimal Convert(decimal decagram)
        {
            return decagram * 10000;
        }
    }

    public class PoundToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_POUND.Name;

        public override decimal Convert(decimal pounds)
        {
            return pounds * (decimal)453592.37;
        }
    }
}
