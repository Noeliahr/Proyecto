using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
{
    public class MedicoDto : EntityDto
    {
        public long? DatosPersonalesId { get; set; }

        public string DatosPersonalesUserName { get; set; }

        public string DatosPersonalesName { get; set; }

        public string DatosPersonalesSurname { get; set; }

        public string DatosPersonalesEmailAddress { get; set; }

        [Required]
        public string Especialidad { get; set; }
    }
}
