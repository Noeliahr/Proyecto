using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Medicos.Dto
{
    public class UserNameMedicoDto : EntityDto
    {
        public string DatosPersonalesUserName { get; set; }
    }
}
