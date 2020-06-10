using System;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using R5T.Alamania;
using R5T.Dacia;
using R5T.Ives.Configuration;
using R5T.Leeds;
using R5T.Lombardy.Standard;
using R5T.Macommania.Default;
using R5T.Shrewsbury.Default;


namespace R5T.Coventry
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureConfigurationServices(this IServiceCollection services)
        {
            // -1.
            var configurationAction = ServiceAction<IConfiguration>.AlreadyAdded;
#pragma warning disable IDE0042 // Deconstruct variable declaration
            var stringlyTypedPathRelatedOperatorsAction = services.AddStringlyTypedPathRelatedOperatorsAction();
            var machineLocationAwareSecretsDirectoryPathProviderAction = services.AddMachineLocationAwareSecretsDirectoryPathProviderAction(
                stringlyTypedPathRelatedOperatorsAction.stringlyTypedPathOperatorAction);
#pragma warning restore IDE0042 // Deconstruct variable declaration

            // 0.
            var configurationNameToAppSettingsFileNameTokenConverterAction = services.AddDefaultConfigurationNameToAppSettingsFileNameTokenConverterAction();
            var defaultAppSettingsJsonFileNameProviderAction = services.AddDefaultAppSettingsJsonFileNameProviderAction();
            var executableFilePathProviderAction = services.AddDefaultExecutableFilePathProviderAction();

            // 1.
            var configurationNameProviderAction = services.AddDirectConfigurationBasedConfigurationNameProviderAction(
                configurationAction);
            var configurationNameSpecificAppSettingsJsonFileNameProviderAction = services.AddConfigurationNameSpecificAppSettingsJsonFileNameProviderAction(
                configurationNameToAppSettingsFileNameTokenConverterAction);
            var executableFileDirectoryPathProviderAction = services.AddDefaultExecutableFileDirectoryPathProviderAction(
                executableFilePathProviderAction,
                stringlyTypedPathRelatedOperatorsAction.stringlyTypedPathOperatorAction);

            // 2.
            var appSettingsDirectoryPathProviderAction = services.AddExecutableFileDirectoryAppSettingsDirectoryPathProvideAction(
                executableFileDirectoryPathProviderAction);

            // 3.
            var configurationNameSpecificAppSettingsJsonFilePathProviderAction = services.AddConfigurationNameSpecificAppSettingsJsonFilePathProviderAction(
                appSettingsDirectoryPathProviderAction,
                configurationNameProviderAction,
                configurationNameSpecificAppSettingsJsonFileNameProviderAction,
                stringlyTypedPathRelatedOperatorsAction.stringlyTypedPathOperatorAction);
            var defaultAppSettingsJsonFilePathProviderAction = services.AddDefaultAppSettingsJsonFilePathProviderAction(
                appSettingsDirectoryPathProviderAction,
                defaultAppSettingsJsonFileNameProviderAction,
                stringlyTypedPathRelatedOperatorsAction.stringlyTypedPathOperatorAction);

            services
                .Run(configurationNameSpecificAppSettingsJsonFilePathProviderAction)
                .Run(defaultAppSettingsJsonFilePathProviderAction)
                .Run(machineLocationAwareSecretsDirectoryPathProviderAction.SecretsDirectoryPathProviderAction)
                .AddSingleton<IRivetOrganizationDirectoryPathProvider, SharedRivetOrganizationDirectoryPathProvider>() // Override.
                ;

            return services;
        }
    }
}
