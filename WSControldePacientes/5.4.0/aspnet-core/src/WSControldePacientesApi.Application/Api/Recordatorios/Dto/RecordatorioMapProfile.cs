using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Recordatorios;

namespace WSControldePacientesApi.Api.Recordatorios.Dto
{
    public class RecordatorioMapProfile :Profile
    {
        public RecordatorioMapProfile()
        {
            CreateMap<RecordatorioDto, Recordatorio>().ReverseMap();
        }
    }
}
