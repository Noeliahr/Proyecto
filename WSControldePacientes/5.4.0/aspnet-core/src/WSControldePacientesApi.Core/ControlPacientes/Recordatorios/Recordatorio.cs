using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.Prescripciones;

namespace WSControldePacientesApi.ControlPacientes.Recordatorios
{
    public class Recordatorio : FullAuditedEntity
    {
        [Required]
        public Paciente Paciente { get; set; }
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public string Texto { get; set; }

        [Required]
        public DateTime FechaHora {get; set;}

    }
}
