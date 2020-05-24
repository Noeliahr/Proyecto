using System.Threading.Tasks;
using WSControldePacientesApi.Configuration.Dto;

namespace WSControldePacientesApi.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
