using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;

namespace WSControldePacientesApi.ControlPacientes.Responsables
{
    public class Responsable : FullAuditedEntity
    {
        [Required]
        public long DatosPersonalesId { get; set; }

        [ForeignKey(nameof(DatosPersonalesId))]
        public User DatosPersonales { get; set; }


        public ICollection<PacienteResponsable> MisPacientes { get; set; }
    }
}
