using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Citas.Dto
{
    public class CitaDto
    {
        public string MedicoDatosPersonalesName { get; set; }
        public string MedicoDatosPersonalesSurname { get; set; }
        public string MedicoDatosPersonalesEmailAddress { get; set; }

        public DateTime FechaHora { get; set; }

        public string Consulta { get; set; }

        public string Servicio_Especialidad { get; set; }

        public string Centro { get; set; }

        public string DireccionTipo { get; set; }

        public string DireccionNombre { get; set; }

        public int DireccionNumero { get; set; }

        public string DireccionLetra { get; set; }

        public int DireccionKm_en_la_via { get; set; }

        public string DireccionBloque { get; set; }

        public string DireccionPortal { get; set; }

        public string DireccionEscalera { get; set; }

        public int DireccionPlanta { get; set; }

        public char DireccionPuerta { get; set; }

        public string DireccionCodigo_Postal { get; set; }

        public string DireccionEntidad_de_Poblacion { get; set; }

        public string DireccionMunicipio { get; set; }
        public string DireccionProvincia { get; set; }

        public string DireccionPais { get; set; }
    }
}
