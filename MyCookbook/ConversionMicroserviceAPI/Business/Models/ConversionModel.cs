using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Models
{
    public class ConversionModel
    {
        public UnitModel UnitFrom { get; set; }

        public double QuantityFrom { get; set; }

        public UnitModel UnitTo { get; set; }

        public double QuantityTo { get; set; }
    }

    //public enum ConversionType
    //{
    //    MilligramToGram = 1,
    //    DecagramToGram = 2,
    //    KilogramToGram = 3,
    //    PoundToGram = 4,
    //    MilligramToKilogram = 5,
    //    DecagramToKilogram = 6,
    //    GramToKilogram = 7,
    //    PoundToKilogram = 8,
    //    MilligramToDecagram = 9,
    //    KilogramToDecagram = 10,
    //    GramToDecagram = 11,
    //    PoundToDecagram = 12,
    //    DecagramToMilligram = 13,
    //    KilogramToMilligram = 14,
    //    GramToMilligram = 15,
    //    PoundToMilligram = 16,
    //    DecagramToPound = 17,
    //    KilogramToPound = 18,
    //    GramToPound = 19,
    //    MilligramToPound = 20,

    //    MilliliterToLiter = 21,
    //    DeciliterToLiter = 22,
    //    TeaspoonToLiter = 23,
    //    TablespoonToLiter = 24,
    //    CupToLiter = 25,

    //    LiterToMilliliter = 26,
    //    DeciliterToMilliliter = 27,
    //    TeaspoonToMilliliter = 28,
    //    TablespoonToMilliliter = 29,
    //    CupToMilliliter = 30,

    //    MilliliterToDeciliter = 31,
    //    LiterToDeciliter = 32,
    //    TeaspoonToDeciliter = 33,
    //    TablespoonToDeciliter = 34,
    //    CupToToDeciliter = 35,

    //    MilliliterToLiter = 21,
    //    DeciliterToLiter = 22,
    //    TeaspoonToLiter = 23,
    //    TablespoonToLiter = 24,
    //    CupToLiter = 25,

    //}
}
