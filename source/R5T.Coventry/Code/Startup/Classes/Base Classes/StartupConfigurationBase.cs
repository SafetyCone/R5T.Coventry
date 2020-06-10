using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Shrewsbury.Extensions;

using RichmondStartupBase = R5T.Richmond.StartupBase;


namespace R5T.Coventry
{
    /// <summary>
    /// A service-based startup configuration.
    /// </summary>
    public abstract class StartupConfigurationBase : RichmondStartupBase
    {
        public StartupConfigurationBase(ILogger<StartupConfigurationBase> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds configuration files.
        /// If overridden, call the base implementation first.
        /// </summary>
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder
                .AddDefaultAndConfigurationSpecificAppSettingsJsonFiles(configurationServiceProvider)
                ;
        }

        /// <summary>
        /// Added services.
        /// If overridden, call the base implementation first.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.ConfigureConfigurationServices();
        }
    }
}
