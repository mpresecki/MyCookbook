using ConversionMicroserviceAPI.Business.Converters;
using ConversionMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Services
{
    public class ConversionService : IConversionService
    {
        public List<IVolumeConverter> volumeConverters { get; set; }

        public List<IMassConverter> massConverters { get; set; }

        public ConversionService()
        {
            volumeConverters = new List<IVolumeConverter>();
            massConverters = new List<IMassConverter>();

            AddVolumeConverters();
            AddMassConverters();
        }


        public ConversionModel ConvertTemperature(ConversionModel conversion)
        {
            if (conversion.UnitFrom.UnitType == conversion.UnitFrom.UnitType && conversion.UnitTo.UnitType == UnitType.Temperature)
            {
                if ( conversion.UnitFrom.UnitName.ToLower().Equals("celsius"))
                {
                    var converter = new CelsiusToFahrenheitConverter();
                    conversion.QuantityTo = converter.Convert(conversion.QuantityFrom);
                }
                else if (conversion.UnitFrom.UnitName.ToLower().Equals("fahrenheit"))
                {
                    var converter = new FahrenheitToCelsiusConverter();
                    conversion.QuantityTo = converter.Convert(conversion.QuantityFrom);
                }
            }

            return conversion;
        }

        public ConversionModel ConvertUnits(ConversionModel conversion)
        {
            ConversionModel conversionResult = null;
            if (conversion.UnitFrom.UnitType == conversion.UnitFrom.UnitType && conversion.UnitTo.UnitType == UnitType.Mass)
            {
                conversionResult = ConvertMassUnits(conversion);
            }
            else if (conversion.UnitFrom.UnitType == conversion.UnitFrom.UnitType && conversion.UnitTo.UnitType == UnitType.Volume)
            {
                conversionResult = ConvertVolumeUnits(conversion);
            }

            return conversionResult;
        }

        private ConversionModel ConvertMassUnits(ConversionModel conversion)
        {
            var converter = massConverters.Find(c => c.UnitFrom == conversion.UnitFrom.UnitName && c.UnitTo == conversion.UnitTo.UnitName);

            conversion.QuantityTo = converter.Convert(conversion.QuantityFrom);

            return conversion;
        }

        private ConversionModel ConvertVolumeUnits(ConversionModel conversion)
        {
            var converter = volumeConverters.Find(c => c.UnitFrom == conversion.UnitFrom.UnitName && c.UnitTo == conversion.UnitTo.UnitName);

            conversion.QuantityTo = converter.Convert(conversion.QuantityFrom);

            return conversion;
        }

        private void AddVolumeConverters()
        {
            ToCupConverter.CreateToCupConverters();
            ToDeciliterConverter.CreateToDecilitersConverters();
            ToLiterConverter.CreateToLiterConverters();
            ToMilliliterConverter.CreateToMilliliterConverters();
            ToTablespoonConverter.CreateToTablespoonConverters();
            ToTeaspoonConverter.CreateToTeaspoonConverters();

            volumeConverters.AddRange(ToCupConverter.toCupConverters);
            volumeConverters.AddRange(ToDeciliterConverter.toDeciliterConverters);
            volumeConverters.AddRange(ToLiterConverter.toLiterConverters);
            volumeConverters.AddRange(ToMilliliterConverter.toMilliliterConverters);
            volumeConverters.AddRange(ToTablespoonConverter.toTablespoonConverters);
            volumeConverters.AddRange(ToTeaspoonConverter.toTeaspoonConverters);
        }

        private void AddMassConverters()
        {
            ToDecagramConverter.CreateToDecagramConverters();
            ToGramConverter.CreateToGramConverters();
            ToKilogramConverter.CreateToKilogramConverters();
            ToMilligramConverter.CreateToMilligramConverters();
            ToPoundConverter.CreateToPoundConverters();

            massConverters.AddRange(ToDecagramConverter.toDecagramConverters);
            massConverters.AddRange(ToGramConverter.toGramConverters);
            massConverters.AddRange(ToKilogramConverter.toKilogramConverters);
            massConverters.AddRange(ToMilligramConverter.toMilligramConverters);
            massConverters.AddRange(ToPoundConverter.toPoundConverters);
        }
    }
}
