using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Citas;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.ControlPacientes.Direcciones
{
    public class Direccion : FullAuditedEntity
    {
        [Required]
        [MaxLength(10)]
        public string Tipo { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Numero { get; set; }

        public string Letra { get; set; }

        public int Kmenlavia { get; set; }

        public string Bloque { get; set; }

        public string Portal { get; set; }

        public string Escalera { get; set; }

        public int Planta { get; set; }

        public char Puerta { get; set; }

        [MaxLength(5)]
        [Required]
        public string CodigoPostal { get; set; }

        public string EntidadePoblacion { get; set; }

        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }

        public ICollection<Paciente> pacientes { get; set; }

        public ICollection<Cita> citas { get; set; }
    }
}
