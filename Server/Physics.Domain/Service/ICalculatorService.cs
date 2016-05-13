using System.Collections.Generic;
using Physics.Domain.PhysicsCalculator;

namespace Physics.Domain.Service
{
    public interface ICalculatorService
    {
        IPhysicsCalculator Physics { get; }
    }
}
