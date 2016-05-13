using Physics.Api.Application.Service;
using Physics.Api.Application.Service.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Physics.Api.Application;
using System.Web.Http.Cors;
using System.Web;
using System.Web.Http.Routing;
using Physics.Api.Models;

namespace Physics.Api.Controllers
{
    [RoutePrefix("api")]
    public class CalculatorController : BaseController
    {
        public CalculatorController(IServices services) : base(services)
        {
        }

        [HttpPost]
        [Route("calculate/density", Name = "CalcDensity")]
        public decimal Density([FromBody]DensityParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateDensity(parameters.Weight, parameters.Volume);

        }
        [HttpPost]
        [Route("calculate/weight", Name = "CalcWeight")]
        public decimal Weight([FromBody]WeightParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateWeight(parameters.Density, parameters.Volume);

        }
        [HttpPost]
        [Route("calculate/volume", Name = "CalcVolume")]
        public decimal Volume([FromBody]VolumeParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateVolume(parameters.Density, parameters.Weight);

        }

    }
}
