using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
{
    public class PagedMedicoResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
