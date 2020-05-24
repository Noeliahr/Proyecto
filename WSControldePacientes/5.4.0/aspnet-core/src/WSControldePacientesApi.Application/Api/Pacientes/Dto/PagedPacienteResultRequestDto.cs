using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class PagedPacienteResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}
