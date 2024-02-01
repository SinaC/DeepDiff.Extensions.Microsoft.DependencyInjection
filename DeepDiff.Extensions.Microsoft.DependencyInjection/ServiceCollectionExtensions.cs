using DeepDiff.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DeepDiff.Extensions.Microsoft.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDeepDiff(this IServiceCollection services, IEnumerable<Assembly> assembliesToScan)
        {
            if (services.Any(sd => sd.ServiceType == typeof(IDeepDiff)))
                return services;

            var deepDiffConfiguration = new DeepDiffConfiguration();
            deepDiffConfiguration.AddProfiles(assembliesToScan.ToArray());

            var deepDiff = deepDiffConfiguration.CreateDeepDiff();
            services.AddSingleton(typeof(IDeepDiff), deepDiff);

            return services;
        }
    }
}