using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using R5T.Derby.Extensions;

using CoventryApplicationStartupBase = R5T.Coventry.ApplicationStartupBase;


namespace R5T.Coventry.Construction
{
    public class Startup : CoventryApplicationStartupBase
    {
        public Startup(ILogger<Startup> logger)
            : base(logger)
        {
        }

        protected override void ConfigureConfigurationBody(IConfigurationBuilder configurationBuilder, IServiceProvider configurationServicesProvider)
        {
            base.ConfigureConfigurationBody(configurationBuilder, configurationServicesProvider);

            configurationBuilder
                .AddRivetUserSecretsFile(configurationServicesProvider, "Authentication-GitHub.json")
                ;
        }
    }
}
