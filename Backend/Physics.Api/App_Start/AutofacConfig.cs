using System.Reflection;
using System.Web.Http;

using Autofac;
using Autofac.Configuration;
using Autofac.Core;
using Autofac.Integration.WebApi;

using Physics.Domain;
using Physics.Domain.Repository;
using Physics.Domain.Service;

namespace Physics.Api.App_Start
{
    public static class AutofacContainer
    {
        const string REPOSITORY_TYPE = "JSON";

        public static void Build()
        {
            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            builder.RegisterWebApiFilterProvider(config);

            builder.RegisterModule(new ConfigurationSettingsReader("dataAccessSection"));

            builder.RegisterType<PhysicsCalculator>().Named<IPhysicsCalculator>("physicsCalculator").InstancePerLifetimeScope();

            builder.RegisterType<CalculatorService>().Named<ICalculatorService>("calculatorService")
                .InstancePerLifetimeScope()
                .WithParameter(GetResolvedParameterByName<IPhysicsCalculator>("physicsCalculator"));

            builder.RegisterType<DensityService>().Named<IDensityService>("densityService")
                .InstancePerLifetimeScope()
                .WithParameters(new[] {
                    GetResolvedParameterByName<IDensityRepository>(REPOSITORY_TYPE),
                    GetResolvedParameterByName<IPhysicsCalculator>("physicsCalculator")
                });

            builder.RegisterType<Services>().As<IServices>().InstancePerLifetimeScope()
                .WithParameters(new[] {
                    GetResolvedParameterByName<IDensityService>("densityService"),
                    GetResolvedParameterByName<ICalculatorService>("calculatorService")
                }); ;
            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static ResolvedParameter GetResolvedParameterByName<T>(string key)
        {
            return new ResolvedParameter(
                (pi, c) => pi.ParameterType == typeof(T),
                (pi, c) => c.ResolveNamed<T>(key));
        }

    }
}