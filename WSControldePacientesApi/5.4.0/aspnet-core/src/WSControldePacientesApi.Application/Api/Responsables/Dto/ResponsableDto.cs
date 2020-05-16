using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Personas.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Responsables.Dto
{
    public class ResponsableDto : EntityDto
    {
        public PersonaDto personaDto { get; set; }

    }
}
