using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.EnfermedadesPacientes.Dto;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;
using WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto
{
    public class EnfermedadPacienteMapProfile : Profile
    {
        public EnfermedadPacienteMapProfile() {
            CreateMap<EnfermedadPaciente, EnfermedadPacienteDto>().ReverseMap();

            CreateMap<MisEnfermedades, EnfermedadPaciente>().ReverseMap();

            CreateMap<PacienteEnfermedadDto, EnfermedadPaciente>().ReverseMap();
        }
    }
}
