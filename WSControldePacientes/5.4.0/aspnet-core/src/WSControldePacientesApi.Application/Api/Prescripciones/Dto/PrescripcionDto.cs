﻿using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Prescripciones.Dto
{
    public class PrescripcionDto : EntityDto
    {
        [Required]
        public string MedicamentoNombre { get; set; }
        [Required]
        public string MedicamentoTipo { get; set; }
        [Required]
        public string MedicamentoGramaje { get; set; }
        [Required]
        public string MedicamentoFuncionalidad { get; set; }
        [Required]
        public string MedicamentoComponenteBase { get; set; }

        [Required]
        public string Dosis { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Final { get; set; }

        [Required]
        public string Como_Tomar { get; set; }
    }
}
