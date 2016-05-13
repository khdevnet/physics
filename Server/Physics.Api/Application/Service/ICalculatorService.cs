using Physics.Api.Application.PhysicsCalculator;
using Physics.Api.Application.Service.Entity;
using System.Collections.Generic;

namespace Physics.Api.Application.Service
{
    public interface ICalculatorService
    {
        IPhysicsCalculator Physics { get; }
    }
}
