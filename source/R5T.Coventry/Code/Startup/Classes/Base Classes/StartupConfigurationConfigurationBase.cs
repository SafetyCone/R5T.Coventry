using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Shrewsbury.Extensions;

using RichmondStartupBase = R5T.Richmond.StartupBase;


namespace R5T.Coventry
{
    /// <summary>
    /// A service-less configuration configuration startup base class.
    /// </summary>
    public abstract class StartupConfigurationConfigurationBase : RichmondStartupBase
    {
        public StartupConfigurationConfigurationBase(ILogger<StartupConfigurationConfigurationBase> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds configuration files.
        /// Do NOT override, or call the base implementation first, which calls <see cref="ConfigureConfigurationBodyServiceLess(IConfigurationBuilder)"/>.
        /// </summary>
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            this.ConfigureConfigurationBodyServiceLess(configurationBuilder);
        }

        /// <summary>
        /// Adds configuration files in a service-less way.
        /// If overridden, call the base implementation first.
        /// </summary>
        protected virtual void ConfigureConfigurationBodyServiceLess(IConfigurationBuilder configurationBuilder)
        {
            configurationBuilder
                .AddDefaultAppSettingsJsonFile()
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
