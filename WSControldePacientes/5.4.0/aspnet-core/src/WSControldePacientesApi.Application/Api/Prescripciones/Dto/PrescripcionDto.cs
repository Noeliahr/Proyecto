using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Api.Medicamentos.Dto;

namespace WSControldePacientesApi.Api.Prescripciones.Dto
{
    public class PrescripcionDto : EntityDto
    {
        [Required]
        public MedicamentoDto medicamento{ get; set; }

        [Required]
        public string Dosis { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Final { get; set; }

        public bool isManana { get; set; }

        public bool isTarde { get; set; }

        public bool isNoche { get; set; }

        public int PacienteId { get; set; }
    }
}
