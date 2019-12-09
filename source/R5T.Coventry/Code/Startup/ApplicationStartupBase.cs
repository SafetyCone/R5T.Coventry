using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using R5T.Coventry.Extensions;

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
        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServicesProvider)
        {
            configurationBuilder
                .AddDefaultAndConfigurationNameSpecificAppSettings(configurationServicesProvider)
                ;
        }
    }
}
