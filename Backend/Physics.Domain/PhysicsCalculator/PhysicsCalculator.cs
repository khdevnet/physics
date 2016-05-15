using System;

namespace Physics.Domain
{
    public class PhysicsCalculator : IPhysicsCalculator
    {
        public float CalculateDensity(float weight, float volume)
        {
            if (volume <= 0) throw new ArgumentException("volume should be greater then 0");
            if (weight <= 0) throw new ArgumentException("weight should be greater then 0");
            var density = weight / volume;
            return density;
        }

        public float CalculateVolume(float density, float weight)
        {
            if (density <= 0) throw new ArgumentException("density should be greater then 0");
            if (weight <= 0) throw new ArgumentException("weight should be greater then 0");
            var volume = weight / density;
            return volume;
        }

        public float CalculateWeight(float density, float volume)
        {
            if (density <= 0) throw new ArgumentException("density should be greater then 0");
            if (volume <= 0) throw new ArgumentException("volume should be greater then 0");
            var weight = density * volume;
            return RoundToKilograms(weight);
        }

        private float RoundToKilograms(float weight) {
            return (float)Math.Round((double)weight, 4);
        }
    }
}