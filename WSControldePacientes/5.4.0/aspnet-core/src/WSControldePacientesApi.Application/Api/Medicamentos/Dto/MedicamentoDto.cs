using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Medicamentos.Dto
{
    public class MedicamentoDto : EntityDto
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Gramaje { get; set; }
        [Required]
        public string Funcionalidad { get; set; }
        [Required]
        public string ComponenteBase { get; set; }
    }
}
