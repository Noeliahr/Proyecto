using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Termometros.Dto
{
    public class PagedTermometroResultRequest : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
