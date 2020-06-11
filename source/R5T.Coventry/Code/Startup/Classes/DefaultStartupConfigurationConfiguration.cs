using System;

using Microsoft.Extensions.Logging;


namespace R5T.Coventry
{
    /// <summary>
    /// Default startup configuration configuration.
    /// </summary>
    public class DefaultStartupConfigurationConfiguration : StartupConfigurationConfigurationBase
    {
        public DefaultStartupConfigurationConfiguration(ILogger<DefaultStartupConfigurationConfiguration> logger)
            : base(logger)
        {
        }
    }
}
