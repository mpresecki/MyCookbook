using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConversionMicroserviceAPI.Business.Converters
{
    public interface IMassConverter
    {
        public string UnitTo { get; }

        public string UnitFrom { get; }

        public abstract decimal Convert(decimal unit);
    }
}
