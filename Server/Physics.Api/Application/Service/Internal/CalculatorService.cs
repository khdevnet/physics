using Physics.Api.Application.PhysicsCalculator;
using Physics.Api.Application.Service.Entity;
using Physics.Api.Application.Storage;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Physics.Api.Application.Service.Internal
{
    public class CalculatorService : ICalculatorService
    {
        public CalculatorService(IPhysicsCalculator physicsCalculator)
        {
            Physics = physicsCalculator;
        }
        public IPhysicsCalculator Physics { get; private set; }
    }
}