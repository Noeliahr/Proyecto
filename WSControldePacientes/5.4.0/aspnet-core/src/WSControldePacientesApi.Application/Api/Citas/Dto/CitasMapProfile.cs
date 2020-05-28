using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Citas;

namespace WSControldePacientesApi.Api.Citas.Dto
{
    public class CitasMapProfile : Profile
    {
        public CitasMapProfile()
        {
            CreateMap<Cita, CitaDto>().ReverseMap();

            CreateMap<Cita, AgendaDto>().ReverseMap();
        }
    }
}
