using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class MisEnfermedades : EntityDto
    {
        public long PacienteNumSeguridadSocial { get; set; }

        public ICollection<EnfermedadPacienteDto> misEnfermedades { get; set;}
    }
}
