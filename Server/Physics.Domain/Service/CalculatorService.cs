
using System;
using System.Collections.Generic;
using System.Linq;
using Physics.Domain.PhysicsCalculator;

namespace Physics.Domain.Service
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