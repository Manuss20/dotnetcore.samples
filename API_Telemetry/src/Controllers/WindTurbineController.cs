using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using API_Telemetry.Models;

namespace API_Telemetry.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WindTurbineController : ControllerBase
    {
        private readonly ILogger<WindTurbineController> _logger;

        public WindTurbineController(ILogger<WindTurbineController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WindTurbine> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 1).Select(index => new WindTurbine
            {
                Date = DateTime.Now.AddDays(index),
                Temperature = rng.Next(-20, 55)
            })
            .ToArray();
        }
    }
}
