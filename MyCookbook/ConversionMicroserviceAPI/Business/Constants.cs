using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business
{
    public class Constants
    {
        public static readonly (string Name, string Abbreviation) UNIT_MASS_GRAM = (Name: "gram", Abbreviation: "g");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_DECAGRAM = (Name: "decagram", Abbreviation: "dag");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_KILOGRAM = (Name: "kilogram", Abbreviation: "kg");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_MILLIGRAM = (Name: "milligram", Abbreviation: "mg");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_POUND = (Name: "pound", Abbreviation: "lb");

        public static readonly (string Name, string Abbreviation) UNIT_PIECE = (Name: "piece", Abbreviation: "piece");

        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_MILLILITER = (Name: "milliliter", Abbreviation: "ml");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_LITER = (Name: "liter", Abbreviation: "l");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_DECILITER = (Name: "deciliter", Abbreviation: "dl");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_TEASPOON = (Name: "teaspoon", Abbreviation: "tsp");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_TABLESPOON = (Name: "tablespoon", Abbreviation: "tbsp");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_CUP = (Name: "cup", Abbreviation: "c");
    }
}
