using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.EnfermedadesPacientes.Dto
{
    public class PacienteEnfermedadDto : EntityDto
    {
        public PacienteDto paciente { get; set; }
    }
}
