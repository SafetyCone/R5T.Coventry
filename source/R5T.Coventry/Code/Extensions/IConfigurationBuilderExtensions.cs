using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Ives;
using R5T.Shrewsbury;

using ShrewsburyFileNames = R5T.Shrewsbury.FileNames;
using ShrewsburyUtilities = R5T.Shrewsbury.Utilities;


namespace R5T.Coventry.Extensions
{
    public static class IConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddDefaultAndConfigurationNameSpecificAppSettings(this IConfigurationBuilder configurationBuilder, IServiceProvider configurationServiceProvider)
        {
            var configurationNameProvider = configurationServiceProvider.GetRequiredService<IConfigurationNameProvider>();

            var configurationName = configurationNameProvider.GetConfigurationName();

            var configurationNameToAppSettingFileTokenConverter = configurationServiceProvider.GetRequiredService<IConfigurationNameToAppSettingsFileNameTokenConverter>();

            var appSettingsFileToken = configurationNameToAppSettingFileTokenConverter.ConvertConfigurationNameToAppSettingsFileNameToken(configurationName);

            var configurationNameSpecificAppSettingsFileName = ShrewsburyUtilities.GetConfigurationNameSpecificAppSettingsJsonFileName(appSettingsFileToken);

            configurationBuilder
                .AddJsonFile(ShrewsburyFileNames.DefaultAppSettingsJsonFileName)
                .AddJsonFile(configurationNameSpecificAppSettingsFileName)
                ;

            return configurationBuilder;
        }
    }
}
