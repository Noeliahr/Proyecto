using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Personas.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
{
    public class MedicoDto : EntityDto
    {
        public PersonaDto personaDto { get; set; }

        [Required]
        public string Especialidad { get; set; }
    }
}
