using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToKilogramConverter : IMassConverter
    {
        public static List<ToKilogramConverter> toKilogramConverters = new List<ToKilogramConverter>();

        public ToKilogramConverter()
        {
            toKilogramConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_MASS_KILOGRAM.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToKilogramConverters()
        {
            _ = new GramToKilogramConverter();
            _ = new DecagramToKilogramConverter();
            _ = new MilligramToKilogramConverter();
            _ = new PoundToKilogramConverter();
        }
    }

    public class GramToKilogramConverter : ToKilogramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_GRAM.Name;

        public override double Convert(double grams)
        {
            return grams / 1000;
        }
    }

    public class DecagramToKilogramConverter : ToKilogramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_DECAGRAM.Name;

        public override double Convert(double decagrams)
        {
            return decagrams / 100;
        }
    }

    public class MilligramToKilogramConverter : ToKilogramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_MILLIGRAM.Name;

        public override double Convert(double milligram)
        {
            return milligram / 1000000;
        }
    }

    public class PoundToKilogramConverter : ToKilogramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_POUND.Name;

        public override double Convert(double pounds)
        {
            return pounds * 0.45359237;
        }
    }
}
