using System;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Liverpool;


namespace R5T.Coventry
{
    /// <summary>
    /// Default startup configuration type.
    /// </summary>
    public class DefaultStartupConfiguration : StartupConfigurationBase
    {
        #region Static

        public static ServiceProvider GetServiceProvider()
        {
            using (var configurationConfigurationServiceProvider = ServiceProviderServiceBuilder.New().UseStartupAndBuild<DefaultStartupConfigurationConfiguration>())
            {
                var configurationServiceProvider = ServiceProviderServiceBuilder.New().UseStartupAndBuild<DefaultStartupConfiguration>(configurationConfigurationServiceProvider);
                return configurationServiceProvider;
            }
        }

        #endregion


        public DefaultStartupConfiguration(ILogger<DefaultStartupConfiguration> logger)
            : base(logger)
        {
        }
    }
}
