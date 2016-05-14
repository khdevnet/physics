﻿using System.Web.Http;

using Physics.Domain.Service;
using Physics.Api.Models;

namespace Physics.Api.Controllers
{
    [RoutePrefix("api")]
    public class CalculatorController : BaseController
    {
        public CalculatorController(IServices services) : base(services) { }

        [HttpPost]
        [Route("calculate/density", Name = "CalcDensity")]
        public float Density([FromBody]DensityParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateDensity(parameters.Weight, parameters.Volume);
        }

        [HttpPost]
        [Route("calculate/weight", Name = "CalcWeight")]
        public float Weight([FromBody]WeightParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateWeight(parameters.Density, parameters.Volume);
        }

        [HttpPost]
        [Route("calculate/volume", Name = "CalcVolume")]
        public float Volume([FromBody]VolumeParameters parameters)
        {
            if (!ModelState.IsValid) BadRequest(ModelState);
            return Services.Calculator.Physics.CalculateVolume(parameters.Density, parameters.Weight);
        }
    }
}
