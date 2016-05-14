using System.Collections.Generic;

namespace Physics.Domain.Service
{
    public interface ICalculatorService
    {
        IPhysicsCalculator Physics { get; }
    }
}
