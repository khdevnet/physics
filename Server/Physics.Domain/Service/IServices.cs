namespace Physics.Domain.Service
{
	public interface IServices
	{
        IDensityService Density { get; }
        ICalculatorService Calculator { get; }
    }
}