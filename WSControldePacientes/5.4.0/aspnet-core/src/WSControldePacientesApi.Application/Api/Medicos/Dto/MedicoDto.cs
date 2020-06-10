using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Api.Citas.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
{
    public class MedicoDto : EntityDto
    {
        public long? DatosPersonalesId { get; set; }

        public string DatosPersonalesUserName { get; set; }

        public string DatosPersonalesName { get; set; }

        public string DatosPersonalesSurname { get; set; }

        public string DatosPersonalesEmailAddress { get; set; }

        public string DatosPersonalesTelefono { get; set; }

        [Required]
        public string Especialidad { get; set; }

        public int TotalPacientes { get; set; }

        public int TotalCitasHoy { get; set; }


        public ICollection<CitaDto> Agenda { get; set; }
    }
}
