using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToDecagramConverter : IMassConverter
    {
        public static List<ToDecagramConverter> toDecagramConverters = new List<ToDecagramConverter>();

        public ToDecagramConverter()
        {
            toDecagramConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_MASS_DECAGRAM.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToDecagramConverters()
        {
            _ = new GramToDecagramConverter();
            _ = new KilogramToDecagramConverter();
            _ = new MilligramToDecagramConverter();
            _ = new PoundToDecagramConverter();
        }
    }

    public class GramToDecagramConverter : ToDecagramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_GRAM.Name;

        public override double Convert(double grams)
        {
            return grams / 10;
        }
    }

    public class KilogramToDecagramConverter : ToDecagramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_KILOGRAM.Name;

        public override double Convert(double kilograms)
        {
            return kilograms * 100;
        }
    }

    public class MilligramToDecagramConverter : ToDecagramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_MILLIGRAM.Name;

        public override double Convert(double milligram)
        {
            return milligram / 10000;
        }
    }

    public class PoundToDecagramConverter : ToDecagramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_POUND.Name;

        public override double Convert(double pounds)
        {
            return pounds * 45.359237;
        }
    }
}
