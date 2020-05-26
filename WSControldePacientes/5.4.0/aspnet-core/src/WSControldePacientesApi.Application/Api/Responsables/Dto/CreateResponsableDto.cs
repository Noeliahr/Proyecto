﻿using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Responsables.Dto
{
    public class CreateResponsableDto : EntityDto
    {
        //DatosPersonales(User)
        //public string Login { get; set; }
        // public MiCrearUserDto DatosPersonales { get; set; }
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string DatosPersonalesUserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string DatosPersonalesName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string DatosPersonalesSurname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string DatosPersonalesEmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string DatosPersonalesTelefono { get; set; }

        public bool DatosPersonalesIsActive { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxPlainPasswordLength)]
        [DisableAuditing]
        public string DatosPersonalesPassword { get; set; }
    }
}