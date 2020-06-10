using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Medicos.Dto;
using WSControldePacientesApi.ControlPacientes.Medicos;

namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
{
    public class MedicoMapProfile : Profile
    {
        public MedicoMapProfile()
        {
            CreateMap<Medico, MedicoDto>().ForMember(m=> m.TotalPacientes, opts=> opts.MapFrom(m=> m.MisPacientes.Count > 0 ? m.MisPacientes.Count : 0))
                                          .ForMember(m=> m.TotalCitasHoy, opts=> opts.Ignore())
                                          .ReverseMap();

            CreateMap<Medico, CreateMedicoDto>().ReverseMap();

            CreateMap<Medico, UserNameMedicoDto>().ReverseMap();

            CreateMap<Medico, EditMedicoDto>().ReverseMap();
        }
    }
}
