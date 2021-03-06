﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public abstract class ToGramConverter : IMassConverter
    {
        public static List<ToGramConverter> toGramConverters = new List<ToGramConverter>();

        public ToGramConverter()
        {
            toGramConverters.Add(this);
        }

        public string UnitTo { get; } = Constants.UNIT_MASS_GRAM.Name;

        public abstract string UnitFrom { get; }

        public abstract decimal Convert(decimal unit);

        public static void CreateToGramConverters()
        {
            _ = new KilogramToGramConverter();
            _ = new DecagramToGramConverter();
            _ = new MilligramToGramConverter();
            _ = new PoundToGramConverter();
        }
    }

    public class KilogramToGramConverter : ToGramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_KILOGRAM.Name;

        public override decimal Convert(decimal kilograms)
        {
            return kilograms * 1000;
        }
    }

    public class DecagramToGramConverter : ToGramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_DECAGRAM.Name;

        public override decimal Convert(decimal decagrams)
        {
            return decagrams * 10;
        }
    }

    public class MilligramToGramConverter : ToGramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_MILLIGRAM.Name;

        public override decimal Convert(decimal milligram)
        {
            return milligram / 1000;
        }
    }

    public class PoundToGramConverter : ToGramConverter
    {
        public override string UnitFrom => Constants.UNIT_MASS_POUND.Name;

        public override decimal Convert(decimal pounds)
        {
            return pounds * (decimal)453.59237;
        }
    }
}
