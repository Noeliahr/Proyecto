using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiControldePacientes.ControlPacientes.Termometros
{
    public class Termometro : FullAuditedEntity
    {
        [Required]
        public string Fabricante { get; set; }
    }
}
