using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto
{
    public class PacienteResponsableDto
    {
        public PacienteDto Paciente { get; set; }

        public ResponsableDto Responsable { get; set; }
    }
}
