using System.IO;
namespace Physics.Api.Application.Service
{
	public interface IServices
	{
        IDensityService Density { get; }
        ICalculatorService Calculator { get; }
    }
}