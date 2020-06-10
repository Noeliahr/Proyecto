using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Api.Prescripciones.Dto;

namespace WSControldePacientesApi.Api.Recordatorios.Dto
{
    public class RecordatorioDto : EntityDto
    {
        public DateTime FechaHora { get; set; }

        [Required]
        public string Texto { get; set; }

        public int idPaciente { get; set; }

    }
}
