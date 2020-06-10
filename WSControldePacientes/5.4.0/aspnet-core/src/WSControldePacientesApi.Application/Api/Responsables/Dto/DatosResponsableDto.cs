﻿using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;

namespace WSControldePacientesApi.Api.Responsables.Dto
{
     public class DatosResponsableDto : EntityDto
    {
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string DatosPersonalesUserName { get; set; }

        [StringLength(AbpUserBase.MaxNameLength)]
        public string DatosPersonalesName { get; set; }

        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string DatosPersonalesSurname { get; set; }

        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string DatosPersonalesEmailAddress { get; set; }

        [MaxLength(15)]
        public string DatosPersonalesTelefono { get; set; }

        public int totalPacientes { get; set; }
    }
}
