using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto
{
    public class DireccionDto : EntityDto
    {
        public string Tipo { get; set; }

        public string Nombre { get; set; }

        public int Numero { get; set; }

        public string Letra { get; set; }

        public int Km_en_la_via { get; set; }

        public string Bloque { get; set; }

        public string Portal { get; set; }

        public string Escalera { get; set; }

        public int Planta { get; set; }

        public char Puerta { get; set; }

        public string Codigo_Postal { get; set; }

        public string Entidad_de_Poblacion { get; set; }

        public string Municipio { get; set; }
        public string Provincia { get; set; }
 
        public string Pais { get; set; }
    }
}
