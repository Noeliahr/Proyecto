using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Users.Dto;
using WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto;
using WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;
using WSControlPacientesApi.ControlPacienteApi.Termometros.Dto;
using WSControlPacientesApi.ControlPacienteApi.Ubicaciones.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class CreatePacienteDto : EntityDto
    {
        [Required]
        public DatosPersonalesDto DatosPersonales { get; set; }
        [Required]
        public long NumSeguridadSocial { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public DireccionDto Donde_vive { get; set; }

        [Required]
        public TermometroDto DatosTermometro { get; set; }

        [Required]
        public decimal Temperatura_Media { get; set; }
        [Required]
        public MedicoDto Creador { get; set; }



    }
}
