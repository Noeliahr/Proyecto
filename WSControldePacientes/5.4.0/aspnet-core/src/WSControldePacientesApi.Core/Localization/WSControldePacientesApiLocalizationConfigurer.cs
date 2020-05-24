using Abp.Configuration.Startup;
using Abp.Localization.Dictionaries;
using Abp.Localization.Dictionaries.Xml;
using Abp.Reflection.Extensions;

namespace WSControldePacientesApi.Localization
{
    public static class WSControldePacientesApiLocalizationConfigurer
    {
        public static void Configure(ILocalizationConfiguration localizationConfiguration)
        {
            localizationConfiguration.Sources.Add(
                new DictionaryBasedLocalizationSource(WSControldePacientesApiConsts.LocalizationSourceName,
                    new XmlEmbeddedFileLocalizationDictionaryProvider(
                        typeof(WSControldePacientesApiLocalizationConfigurer).GetAssembly(),
                        "WSControldePacientesApi.Localization.SourceFiles"
                    )
                )
            );
        }
    }
}
