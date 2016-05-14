namespace Physics.Domain
{
    public interface IPhysicsCalculator
    {
        float CalculateDensity(float weight, float volume);
        float CalculateWeight(float density, float volume);
        float CalculateVolume(float density, float weight);
    }
}
