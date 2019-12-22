using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using R5T.Derby.Extensions;

using RichmondApplicationStartupBase = R5T.Richmond.ApplicationStartupBase;


namespace R5T.Coventry
{
    public abstract class ApplicationStartupBase : RichmondApplicationStartupBase
    {
        public ApplicationStartupBase(ILogger<ApplicationStartupBase> logger)
            : base(logger)
        {
        }

        /// <summary>
        /// Adds default and configuration name-specific appsettings.json files.
        /// </summary>
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            configurationBuilder
                .AddDefaultAndConfigurationSpecificAppSettingsJsonFiles(configurationServiceProvider, true) // Make the configuration-name-specific appsettings file optional since all configuration might just be in the default appsettings file.
                ;
        }

        /// <summary>
        /// Adds console logging.
        /// </summary>
        protected override void ConfigureServicesBody(IServiceCollection services)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
            });
        }
    }
}
