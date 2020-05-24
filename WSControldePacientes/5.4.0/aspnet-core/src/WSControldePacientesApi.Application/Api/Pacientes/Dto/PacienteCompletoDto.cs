using Abp.Application.Services.Dto;
using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;
using WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;
using WSControlPacientesApi.ControlPacienteApi.Termometros.Dto;

namespace WSControldePacientesApi.Api.Pacientes.Dto
{
    public class PacienteCompletoDto : EntityDto
    {
        
        //DatosPersonales(User)
        public long DatosPersonalesId { get; set; }
        public string DatosPersonalesUserName { get; set; }
        public string DatosPersonalesName { get; set; }
        public string DatosPersonalesSurname { get; set; }
        [EmailAddress]
        public string DatosPersonalesEmailAddress { get; set; }
        public string DatosPersonalesTelefono { get; set; }

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
        public string DondeViveCodigo_Postal { get; set; }
        public string DondeViveEntidad_de_Poblacion { get; set; }
        public string DondeViveMunicipio { get; set; }
        public string DondeViveProvincia { get; set; }
        public string DondeVivePais { get; set; }

        //Datos del termometro
        public int TermometroId { get; set; }
        public string TermometroFabricante { get; set; }
  
        public decimal Temperatura_Media { get; set; }

        //Datos del Medico
        public int MiMedicoCabeceraId { get; set; }
        public long? MiMedicoCabeceraDatosPersonalesId { get; set; }
        public string MiMedicoCabeceraDatosPersonalesUserName { get; set; }
        public string MiMedicoCabeceraDatosPersonalesName { get; set; }
        public string MiMedicoCabeceraDatosPersonalesSurname { get; set; }
        public string MiMedicoCabeceraDatosPersonalesEmailAddress { get; set; }
        public string MiMedicoCabeceraDatosPersonalesTelefono { get; set; }
        public string MiMedicoCabeceraEspecialidad { get; set; }


    }
}
