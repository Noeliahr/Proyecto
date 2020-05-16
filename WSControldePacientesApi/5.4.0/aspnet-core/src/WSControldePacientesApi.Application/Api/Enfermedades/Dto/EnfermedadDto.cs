using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Enfermedades.Dto
{
    public class EnfermedadDto : EntityDto
    {
        [Required]
        public string Nombre;

        [Required]
        public string Sintomas;
    }
}
