using ConversionMicroserviceAPI.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Services
{
    public interface IConversionService
    {
        ConversionModel ConvertUnits(ConversionModel conversion);

        ConversionModel ConvertTemperature(ConversionModel conversion);
    }
}
