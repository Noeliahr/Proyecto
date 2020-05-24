using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Termometros.Dto
{
    public class TermometroDto : EntityDto
    {
        [Required]
        public string Fabricante { get; set; }
    }
}
