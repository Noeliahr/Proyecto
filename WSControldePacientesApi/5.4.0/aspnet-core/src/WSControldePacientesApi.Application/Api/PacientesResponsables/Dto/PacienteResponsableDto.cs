using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto
{
    public class PacienteResponsableDto
    {
        public PacienteDto Paciente { get; set; }

        public ResponsableDto Responsable { get; set; }
    }
}
