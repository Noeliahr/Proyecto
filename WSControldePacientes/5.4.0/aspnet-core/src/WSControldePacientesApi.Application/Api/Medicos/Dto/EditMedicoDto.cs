using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Medicos.Dto
{
    public class EditMedicoDto : EntityDto
    {
        public string DatosPersonalesUserName { get; set; }

        public string DatosPersonalesName { get; set; }

        public string DatosPersonalesSurname { get; set; }

        public string DatosPersonalesEmailAddress { get; set; }

        public string DatosPersonalesTelefono { get; set; }

        [Required]
        public string Especialidad { get; set; }
    }
}
