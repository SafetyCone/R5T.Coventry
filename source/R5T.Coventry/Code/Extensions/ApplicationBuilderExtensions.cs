using System;

using R5T.Derby;
using R5T.Richmond;


namespace R5T.Coventry
{
    public static class ApplicationBuilderExtensions
    {
        public static IServiceProvider UseStartupFromCoventryWithDerbyConfigurationStartup<TStartup>(this ApplicationBuilder applicationBuilder)
            where TStartup: ApplicationStartupBase
        {
            var serviceProvider = applicationBuilder.UseStartupWithDerbyConfigurationStartup<TStartup>();
            return serviceProvider;
        }
    }
}
