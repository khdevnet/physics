namespace Physics.Domain.Service
{
    public class CalculatorService : ICalculatorService
    {
        IPhysicsCalculator _physicsCalculator;

        public CalculatorService(IPhysicsCalculator physicsCalculator)
        {
            _physicsCalculator = physicsCalculator;
        }

        public IPhysicsCalculator Physics { get { return _physicsCalculator; } }
    }
}