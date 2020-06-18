﻿using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;
using WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto;
using WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;
using WSControlPacientesApi.ControlPacienteApi.Ubicaciones.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class CreatePacienteDto : EntityDto
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

        public string[] DatosPersonalesRoleNames { get; set; }

        public DateTime FechaNacimiento { get; set; }

        public long NumSeguridadSocial { get; set; }

        //Datos de la Direccion
        public int DondeViveId { get; set; }
        public string DondeViveTipo { get; set; }
        public string DondeViveNombre { get; set; }
        public int DondeViveNumero { get; set; }
        public string DondeViveLetra { get; set; }
        public int DondeViveKm_en_la_via { get; set; }
        public string DondeViveBloque { get; set; }
        public string DondeVivePortal { get; set; }
        public string DondeViveEscalera { get; set; }
        public int DondeVivePlanta { get; set; }
        public char DondeVivePuerta { get; set; }
        public string DondeViveCodigoPostal { get; set; }
        public string DondeViveEntidad_de_Poblacion { get; set; }
        public string DondeViveMunicipio { get; set; }
        public string DondeViveProvincia { get; set; }
        public string DondeVivePais { get; set; }

       



    }
}
