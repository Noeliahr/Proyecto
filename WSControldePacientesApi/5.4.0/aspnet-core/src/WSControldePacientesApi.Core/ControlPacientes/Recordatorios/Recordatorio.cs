using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Prescripciones;

namespace WSControldePacientesApi.ControlPacientes.Recordatorios
{
    public class Recordatorio : FullAuditedEntity
    {
        [Required]
        public Prescripcion Prescripcion { get; set; }
        [Required]
        public int PrescripcionId { get; set; }

        [Required]
        public string Texto { get; set; }

    }
}
