using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Prescripciones.Dto
{
    public class PrescripcionDto : EntityDto
    {
        [Required]
        public int MedicamentoId { get; set; }
        public string MedicamentoNombre { get; set; }
        public string MedicamentoTipo { get; set; }
        public string MedicamentoGramaje { get; set; }
        public string MedicamentoFuncionalidad { get; set; }
        public string MedicamentoComponenteBase { get; set; }

        [Required]
        public string Dosis { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Final { get; set; }

        [Required]
        public string Como_Tomar { get; set; }


        public int PacienteId { get; set; }
    }
}
