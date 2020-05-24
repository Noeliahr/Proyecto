using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Users.Dto;

namespace WSControldePacientesApi.Api.Responsables.Dto
{
     public class DatosResponsableDto : EntityDto
    {
        public UserDto DatosPersonales { get; set; }
    }
}
