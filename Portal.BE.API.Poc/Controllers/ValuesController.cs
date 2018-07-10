using Microsoft.AspNetCore.Mvc;
using Portal.BE.API.Poc.Chassis.Filters;
using Portal.BE.API.Poc.Chassis.Logging;
using Serilog;
using System;
using System.Collections.Generic;

namespace Portal.BE.API.Poc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExceptionFilter]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {
                "value1",
                "value2"
            };
        }

        // GET api/all
        [HttpGet("all")]
        public ActionResult<IEnumerable<string>> ThrowAll()
        {
            throw new Exception("Unhandled Example");
        }

        // GET api/custom
        [HttpGet("custom")]
        public ActionResult<string> ThrowCustom()
        {
            throw new ApiException("This is a custom exception");
        }

        // GET api/notallowed
        [HttpGet("notallowed")]
        public ActionResult<string> Throw401()
        {
            throw new UnauthorizedAccessException("This is a custom 401 exception");
        }

        [HttpGet("serilog")]
        public ActionResult<string> Serilog()
        {
            Log.Information("Serilog Sample");

            return Ok();
        }
    }
}
