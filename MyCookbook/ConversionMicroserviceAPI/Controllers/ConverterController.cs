using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConversionMicroserviceAPI.Business.Models;
using ConversionMicroserviceAPI.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConversionMicroserviceAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConverterController : ControllerBase
    {
        private IConversionService _service;

        public ConverterController(IConversionService service)
        {
            _service = service;
        }

        [HttpPut]
        [Route("units")]
        public ActionResult<ConversionModel> ConvertUnits(ConversionModel conversion)
        {
            return Ok(_service.ConvertUnits(conversion));
        }

        [HttpPut]
        [Route("temperature")]
        public ActionResult<ConversionModel> ConvertUTemperature(ConversionModel conversion)
        {
            return Ok(_service.ConvertTemperature(conversion));
        }
    }
}