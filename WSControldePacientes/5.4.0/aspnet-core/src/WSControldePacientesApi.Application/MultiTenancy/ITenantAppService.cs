using Abp.Application.Services;
using WSControldePacientesApi.MultiTenancy.Dto;

namespace WSControldePacientesApi.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

