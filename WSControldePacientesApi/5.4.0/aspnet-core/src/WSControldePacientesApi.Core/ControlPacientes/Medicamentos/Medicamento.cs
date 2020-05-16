using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.ControlPacientes.Medicamentos
{
    public class Medicamento : FullAuditedEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public decimal Gramaje { get; set; }
        [Required]
        public string Funcionalidad { get; set; }
        [Required]
        public string Componente_Base { get; set; }
    }
}
