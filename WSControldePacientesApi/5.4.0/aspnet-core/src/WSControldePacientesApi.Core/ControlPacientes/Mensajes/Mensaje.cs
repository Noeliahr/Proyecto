using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WSControldePacientesApi.Authorization.Users;

namespace WSControldePacientesApi.ControlPacientes.Mensajes
{
    public class Mensaje : FullAuditedEntity
    {
        [ForeignKey(nameof(PersonaOrigenId))]
        public User PersonaOrigen { get; set; }
        [Required]
        public long PersonaOrigenId { get; set; }

        [ForeignKey(nameof(PersonaDestinoId))]
        public User PersonaDestino { get; set; }
        [Required]
        public long PersonaDestinoId { get; set; }

        [Required]
        [MaxLength(120)]
        public string Texto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public bool isLeido { get; set; }

        [Required]
        public bool isRecibido { get; set; }


    }
}
