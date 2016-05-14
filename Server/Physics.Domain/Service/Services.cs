namespace Physics.Domain.Service
{
	public class Services : IServices
	{
		public Services(IDensityService densityService, ICalculatorService calculatorService)
		{
            Density = densityService;
            Calculator = calculatorService;
        }
        
        public IDensityService Density { get; private set; }
        public ICalculatorService Calculator { get; private set; }
    }
}