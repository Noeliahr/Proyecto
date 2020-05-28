using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControldePacientesApi.Api.PacientesResponsables
{
    public  class PacienteResponsableDto : EntityDto
    {
        public PacienteDto paciente { get; set; }

        public ResponsableDto responsable { get; set; }
    }
}
