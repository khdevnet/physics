using System.Collections.Generic;

namespace Physics.Domain.PhysicsCalculator
{
    public interface IPhysicsCalculator
    {
        decimal CalculateDensity(decimal weight, decimal volume);
        decimal CalculateWeight(decimal density, decimal volume);
        decimal CalculateVolume(decimal density, decimal weight);
    }
}
