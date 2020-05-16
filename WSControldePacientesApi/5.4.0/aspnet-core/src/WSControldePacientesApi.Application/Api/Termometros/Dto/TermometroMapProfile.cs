using ApiControldePacientes.ControlPacientes.Termometros;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControlPacientesApi.ControlPacienteApi.Termometros.Dto
{
    public class TermometroMapProfile : Profile
    {
        public TermometroMapProfile() {
            CreateMap<Termometro, TermometroDto>().ReverseMap();
        }
    }
}
