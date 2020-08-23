using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToPoundConverter : IMassConverter
    {
        public static List<ToPoundConverter> toPoundConverters = new List<ToPoundConverter>();

        public ToPoundConverter()
        {
            toPoundConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_MASS_POUND.Name;

        public abstract string UnitFrom { get; }

        public abstract double Convert(double unit);

        public static void CreateToPoundConverters()
        {
            _ = new GramToPoundConverter();
            _ = new KilogramToPoundConverter();
            _ = new DecagramToPoundConverter();
            _ = new MilligramToPoundConverter();
        }
    }

    public class GramToPoundConverter : ToPoundConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_GRAM.Name;

        public override double Convert(double grams)
        {
            return grams * 0.00220462262;
        }
    }

    public class KilogramToPoundConverter : ToPoundConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_KILOGRAM.Name;

        public override double Convert(double kilograms)
        {
            return kilograms * 2.20462262;
        }
    }

    public class DecagramToPoundConverter : ToPoundConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_DECAGRAM.Name;

        public override double Convert(double decagram)
        {
            return decagram * 0.0220462262;
        }
    }

    public class MilligramToPoundConverter : ToPoundConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_MILLIGRAM.Name;

        public override double Convert(double milligrams)
        {
            return milligrams * (2.20462262 / 1000000);
        }
    }
}
