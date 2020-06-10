using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using R5T.Shrewsbury.Extensions;

using RichmondStartupBase = R5T.Richmond.StartupBase;


namespace R5T.Coventry
{
    public abstract class StartupBase : RichmondStartupBase
    {
        public StartupBase(ILogger<StartupBase> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds the default and configuration name-specific appsettings.json files to the configuration.
        /// If overridden, call the base implementation first.
        /// </summary>
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder
                .AddDefaultAndConfigurationSpecificAppSettingsJsonFiles(configurationServiceProvider, false, false)
                ;
        }
    }
}
