using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Recordatorios.Dto;

namespace WSControldePacientesApi.Api.Pacientes.Dto
{
    public class MisRecordatorios : EntityDto
    {
        public ICollection<RecordatorioDto> recordatorios { get; set; }
    }
}
