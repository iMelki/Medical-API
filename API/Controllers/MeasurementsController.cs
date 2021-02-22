using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DataTransferObjects;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMeasurementsRepository _measuRep;
        public MeasurementsController(
            IMeasurementsRepository measuRep
        )
        {
            _measuRep = measuRep;
        }

        // GET api/measurements
        [HttpGet]
        public async Task<IActionResult> GetMeasurements()
        {
            /*
            List<Measurement> measurements = new List<Measurement>();
            measurements.Add(new Measurement{
                time = DateTime.Now,
                Albumin = 2.5F
            });
            */
            List<Measurement> measurements = await _measuRep.GetMeasurements();
            measurements.Reverse();
            return Ok(measurements);
        }

        // PUT api/measurements/register{...}
        [HttpPut("register")]
        public async Task<IActionResult> Register(Measurement measurement)
        {
            var measurementToCreate = new Measurement
            {
                time = DateTime.Now,
                Platelets = measurement.Platelets,
                Albumin = measurement.Albumin
            };

            var createdMeasurement = await _measuRep.Register(measurementToCreate);

            return Ok(new{
                time = createdMeasurement.time,
                Platelets = createdMeasurement.Platelets,
                Albumin = createdMeasurement.Albumin
            });
        }

        // PUT api/Measurements/recommend{...}
        [HttpPut("recommend")]
        public double Recommend(MeasurementForRecommendationDto measurement)
        {
            var ans = 0.0;
            var op = measurement.Operator;
            var p = measurement.Platelets;
            var a = measurement.Albumin;
            if (op=="+") ans = p+a;
            else if (op=="-") ans = p-a;
            else if (op=="*") ans = p*a;
            else if (op=="/") ans = p/a;
            
            return ans;
            /*
            return Ok(new{
                res = ans
            });*/
        }
    }
}
