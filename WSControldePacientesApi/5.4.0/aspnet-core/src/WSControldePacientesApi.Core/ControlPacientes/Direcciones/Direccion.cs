using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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

        public int Km_en_la_via { get; set; }

        public string Bloque { get; set; }

        public string Portal { get; set; }

        public string Escalera { get; set; }

        public int Planta { get; set; }

        public char Puerta { get; set; }

        [MaxLength(5)]
        [Required]
        public string Codigo_Postal { get; set; }

        public string Entidad_de_Poblacion { get; set; }

        [Required]
        public string Municipio { get; set; }
        [Required]
        public string Provincia { get; set; }
        [Required]
        public string Pais { get; set; }
    }
}
