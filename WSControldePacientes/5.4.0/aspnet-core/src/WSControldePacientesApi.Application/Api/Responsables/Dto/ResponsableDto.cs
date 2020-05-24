using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Responsables.Dto
{
    public class ResponsableDto : EntityDto
    {
        [Required]
        [StringLength(AbpUserBase.MaxUserNameLength)]
        public string ResponsableDatosPersonalesUserName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxNameLength)]
        public string ResponsableDatosPersonalesName { get; set; }

        [Required]
        [StringLength(AbpUserBase.MaxSurnameLength)]
        public string ResponsableDatosPersonalesSurname { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(AbpUserBase.MaxEmailAddressLength)]
        public string ResponsableDatosPersonalesEmailAddress { get; set; }

        [Required]
        [MaxLength(15)]
        public string ResponsableDatosPersonalesTelefono { get; set; }

    }
}
