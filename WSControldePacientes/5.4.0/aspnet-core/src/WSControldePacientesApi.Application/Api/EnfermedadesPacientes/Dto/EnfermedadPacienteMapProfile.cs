using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;

namespace WSControlPacientesApi.ControlPacienteApi.EnfermedadesPacientes.Dto
{
    public class EnfermedadPacienteMapProfile : Profile
    {
        public EnfermedadPacienteMapProfile() {
            CreateMap<EnfermedadPaciente, EnfermedadPacienteDto>().ReverseMap();
        }
    }
}
