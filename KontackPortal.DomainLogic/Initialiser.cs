using System.Diagnostics.CodeAnalysis;
using KontackPortal.DomainLogic.Interface;
using KontackPortal.DomainLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace KontackPortal.DomainLogic
{
    [ExcludeFromCodeCoverage]
    public static class Initialiser
    {
        public static void AddDomainLogicServices(this IServiceCollection services)
        {
            services.AddTransient<IContactService, ContactServices>();
        }
        
        public static void AddEnvironmentService(this IServiceCollection services, string runtimeEnvironment) =>
            services.AddSingleton(_ => new EnvironmentService(runtimeEnvironment));
    }
}