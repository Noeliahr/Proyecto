using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class MisResponsables : EntityDto
    {
        [Required]
        [MinLength(12)]
        [MaxLength(13)]
        public long NumSeguridadSocial { get; set; }

        public string PacienteDatosPersonalesFullName { get; set; }

        public ICollection<PacienteMiResponsableDto> Responsables { get; set; }
    }
}
