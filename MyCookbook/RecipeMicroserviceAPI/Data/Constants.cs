using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeMicroserviceAPI.Data
{
    public static class Constants
    {
        public static readonly string SKILL_EASY = "Easy";
        public static readonly string SKILL_MEDIUM = "Moderate";
        public static readonly string SKILL_HARD = "Hard";

        public static readonly string CATEGORY_WARM_APPETIZER = "Warm appetizer";
        public static readonly string CATEGORY_COLD_APPETIZER = "Cold appetizer";
        public static readonly string CATEGORY_MAIN_DISH = "Main dish";
        public static readonly string CATEGORY_SIDE_DISH = "Side dish";
        public static readonly string CATEGORY_SALADS = "Salads";
        public static readonly string CATEGORY_DESSERT = "Dessert";
        public static readonly string CATEGORY_SAUCES = "Sauces";
        public static readonly string CATEGORY_SOUPS = "Soups";

        public static readonly (string Name, string Abbreviation) UNIT_MASS_GRAM = (Name: "gram", Abbreviation: "g");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_DECAGRAM = (Name: "decagram", Abbreviation: "dag");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_KILOGRAM = (Name: "kilogram", Abbreviation: "kg");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_MILLIGRAM = (Name: "milligram", Abbreviation: "mg");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_POUND = (Name: "pound", Abbreviation: "lb");
        public static readonly (string Name, string Abbreviation) UNIT_MASS_OUNCE = (Name: "ounce", Abbreviation: "oz");

        public static readonly (string Name, string Abbreviation) UNIT_PIECE = (Name: "piece", Abbreviation: "piece");

        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_MILLILITER = (Name: "milliliter", Abbreviation: "ml");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_LITER = (Name: "liter", Abbreviation: "l");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_DECILITER = (Name: "deciliter", Abbreviation: "dl");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_TEASPOON = (Name: "teaspoon", Abbreviation: "tsp");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_TABLESPOON = (Name: "tablespoon", Abbreviation: "tbsp");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_CUP = (Name: "cup", Abbreviation: "c");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_PINT = (Name: "pint", Abbreviation: "pt");
        public static readonly (string Name, string Abbreviation) UNIT_VOLUME_FLUID_OUNCE = (Name: "fluid ounce", Abbreviation: "fl oz");
    }
}
