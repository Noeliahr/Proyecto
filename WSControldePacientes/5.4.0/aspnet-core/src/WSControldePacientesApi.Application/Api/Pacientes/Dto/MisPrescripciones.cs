using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Prescripciones.Dto;

namespace WSControldePacientesApi.Api.Pacientes.Dto
{
    public class MisPrescripciones : EntityDto
    {
        public ICollection<PrescripcionDto> misPrescripciones { get; set; }
    }
}
