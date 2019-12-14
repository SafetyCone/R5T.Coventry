using System;

using R5T.Derby;
using RichmondApplicationBuilder = R5T.Richmond.ApplicationBuilder;


namespace R5T.Coventry
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceProvider UseStartupFromCoventryWithDerbyConfigurationStartup<TStartup>(this RichmondApplicationBuilder applicationBuilder)
            where TStartup: ApplicationStartupBase
        {
            var serviceProvider = applicationBuilder.UseStartupWithDerbyConfigurationStartup<TStartup>();
            return serviceProvider;
        }
    }
}
