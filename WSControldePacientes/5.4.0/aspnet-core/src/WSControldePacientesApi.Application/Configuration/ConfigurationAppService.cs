using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using WSControldePacientesApi.Configuration.Dto;

namespace WSControldePacientesApi.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : WSControldePacientesApiAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
