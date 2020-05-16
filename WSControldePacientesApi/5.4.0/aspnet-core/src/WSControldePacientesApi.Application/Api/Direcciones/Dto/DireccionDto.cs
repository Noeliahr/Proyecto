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

        public int Piso { get; set; }

        public char Escalera { get; set; }

        public int Bloque { get; set; }

        public string Codigo_Postal { get; set; }

        public string Municipio { get; set; }
       
        public string Provincia { get; set; }
    }
}
