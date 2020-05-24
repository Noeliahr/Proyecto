using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Recordatorios.Dto
{
    public class RecordatorioDto : EntityDto
    {
        [Required]
        public string PrescripcionMedicamentoNombre { get; set; }
        [Required]
        public string PrescripcionMedicamentoTipo { get; set; }
        [Required]
        public decimal PrescripcionMedicamentoGramaje { get; set; }
        [Required]
        public string PrescripcionMedicamentoFuncionalidad { get; set; }
        [Required]
        public string PrescripcionMedicamentoComponente_Base { get; set; }

        [Required]
        public decimal PrescripcionDosis { get; set; }

        [Required]
        public DateTime PrescripcionFecha_Inicio { get; set; }

        [Required]
        public DateTime PrescripcionFecha_Final { get; set; }

        [Required]
        public string PrescripcionComo_Tomar { get; set; }

        [Required]
        public string Texto { get; set; }


    }
}
