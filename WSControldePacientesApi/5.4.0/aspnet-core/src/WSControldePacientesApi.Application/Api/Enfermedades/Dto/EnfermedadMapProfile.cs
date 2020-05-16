using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Enfermedades;

namespace WSControlPacientesApi.ControlPacienteApi.Enfermedades.Dto
{
    public class EnfermedadMapProfile : Profile
    {
        public EnfermedadMapProfile() {
            CreateMap<Enfermedad, EnfermedadDto>().ForMember(en => en.Nombre, opts => opts.MapFrom(enfermedad => enfermedad.Nombre))
                                                  .ForMember(en => en.Sintomas, opts => opts.MapFrom(enfermedad => enfermedad.Sintomas))
                                                  .ReverseMap();

        }
    }
}
