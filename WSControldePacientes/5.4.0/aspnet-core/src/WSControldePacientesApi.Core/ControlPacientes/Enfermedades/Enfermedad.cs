using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;

namespace WSControldePacientesApi.ControlPacientes.Enfermedades
{
    public class Enfermedad : FullAuditedEntity
    {
        [Required]
        public string Nombre { get; set; }

        public string Sintomas { get; set; }

        public string Causas { get; set; }

        public ICollection<EnfermedadPaciente> enfermedadPacientes { get; set; }
    }
}
