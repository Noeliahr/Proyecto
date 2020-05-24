using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Responsables.Dto
{
    public class PagedResponsableResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
