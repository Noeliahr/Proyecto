using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Enfermedades.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto
{
    public class EnfermedadPacienteDto : EntityDto
    {
        public EnfermedadDto enfermedad { get; set; }
    }
}
