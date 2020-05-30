using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Citas.Dto
{
    public class CreateCitaDto : EntityDto
    {
        public int PacienteId { get; set; }

        public DateTime FechaHora { get; set; }

        public string Consulta { get; set; }

        public string Servicio_Especialidad { get; set; }

        public string Centro { get; set; }

        public string DireccionTipo { get; set; }

        public string DireccionNombre { get; set; }

        public int DireccionNumero { get; set; }

        public string DireccionLetra { get; set; }

        public int DireccionKmenlavia { get; set; }

        public string DireccionBloque { get; set; }

        public string DireccionPortal { get; set; }

        public string DireccionEscalera { get; set; }

        public int DireccionPlanta { get; set; }

        public char DireccionPuerta { get; set; }

        public string DireccionCodigoPostal { get; set; }

        public string DireccionEntidaddePoblacion { get; set; }

        public string DireccionMunicipio { get; set; }
        public string DireccionProvincia { get; set; }

        public string DireccionPais { get; set; }
    }
}
