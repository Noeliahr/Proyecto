using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;
using WSControlPacientesApi.ControlPacienteApi.Termometros.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class PacienteDto :EntityDto
    {
        [Required]
        public long NumSeguridadSocial { get; set; }

        [Required]
        public DatosPersonalesDto datosPersonales { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

    }
}
