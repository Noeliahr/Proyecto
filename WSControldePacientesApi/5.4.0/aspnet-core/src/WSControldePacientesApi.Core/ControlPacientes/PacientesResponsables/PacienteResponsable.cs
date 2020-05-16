using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.Responsables;

namespace WSControldePacientesApi.ControlPacientes.PacientesResponsables
{
    public class PacienteResponsable : FullAuditedEntity
    {
        public int PacienteId { get; set; }
        public Paciente Paciente { get; set; }

        public int ResponsableId { get; set; }
        public Responsable Responsable { get; set; }
    }
}
