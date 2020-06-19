using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class PacienteDto :EntityDto
    {
        public long NumSeguridadSocial { get; set; }

        public long DatosPersonalesId { get; set; }

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

        public DateTime FechaNacimiento { get; set; }

    }
}
