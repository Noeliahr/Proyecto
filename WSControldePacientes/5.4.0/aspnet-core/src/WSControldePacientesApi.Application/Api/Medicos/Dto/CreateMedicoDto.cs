using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Medicos.Dto
{
    public class CreateMedicoDto : EntityDto
    {
        [Required]
        public long? DatosPersonalesId { get; set; }

        [Required]
        public string Especialidad { get; set; }
    }
}
