using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Mensajes.Dto
{
    public class PagedMensajeResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
