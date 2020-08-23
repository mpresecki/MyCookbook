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

        public abstract double Convert(double unit);

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

        public override double Convert(double grams)
        {
            return grams * 1000;
        }
    }

    public class KilogramToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_KILOGRAM.Name;

        public override double Convert(double kilograms)
        {
            return kilograms * 1000000;
        }
    }

    public class DecagramToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_DECAGRAM.Name;

        public override double Convert(double decagram)
        {
            return decagram * 10000;
        }
    }

    public class PoundToMilligramConverter : ToMilligramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_POUND.Name;

        public override double Convert(double pounds)
        {
            return pounds * 453592.37;
        }
    }
}
