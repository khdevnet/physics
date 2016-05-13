using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Physics.Api.Application.PhysicsCalculator
{
    public class PhysicsCalculator : IPhysicsCalculator
    {
        public decimal CalculateDensity(decimal weight, decimal volume)
        {
            if (volume <= 0) throw new ArgumentException("volume should be greater then 0");
            if (weight <= 0) throw new ArgumentException("weight should be greater then 0");
            return weight / volume;
        }

        public decimal CalculateVolume(decimal density, decimal weight)
        {
            if (density <= 0) throw new ArgumentException("density should be greater then 0");
            if (weight <= 0) throw new ArgumentException("weight should be greater then 0");
            return weight / density;
        }

        public decimal CalculateWeight(decimal density, decimal volume)
        {
            if (density <= 0) throw new ArgumentException("density should be greater then 0");
            if (volume <= 0) throw new ArgumentException("volume should be greater then 0");
            return density * volume;
        }
    }
}