using System.Threading.Tasks;
using Abp.Application.Services;
using WSControldePacientesApi.Sessions.Dto;

namespace WSControldePacientesApi.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
