using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Enfermedades;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.ControlPacientes.EnfermadesPacientes
{
    public class EnfermedadPaciente : FullAuditedEntity
    {
        [Required]
        public Enfermedad Enfermedad { get; set; }

        [Required]
        public int EnfermedadId { get; set; }

        [Required]
        public Paciente Paciente { get; set; }

        [Required]
        public int PacienteId { get; set; }
    }
}
