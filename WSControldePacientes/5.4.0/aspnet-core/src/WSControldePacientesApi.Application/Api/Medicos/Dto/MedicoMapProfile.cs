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
            CreateMap<Medico, MedicoDto>().ReverseMap();

            CreateMap<Medico, CreateMedicoDto>().ReverseMap();

            CreateMap<Medico, UserNameMedicoDto>().ReverseMap();
        }
    }
}
