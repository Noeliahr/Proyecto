using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Prescripciones.Dto;
using WSControldePacientesApi.Api.Recordatorios.Dto;

namespace WSControldePacientesApi.Api.Pacientes.Dto
{
    public class MisRecordatorios : EntityDto
    {
        public ICollection<PrescripcionRecordatorio> misprescripciones { get; set;}
    }
}
