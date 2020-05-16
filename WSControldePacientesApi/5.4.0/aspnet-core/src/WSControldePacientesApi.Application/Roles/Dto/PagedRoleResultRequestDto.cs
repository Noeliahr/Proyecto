using Abp.Application.Services.Dto;

namespace WSControldePacientesApi.Roles.Dto
{
    public class PagedRoleResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

