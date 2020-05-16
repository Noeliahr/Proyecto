using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;

namespace WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto
{
    public class PacienteResponsableMapProfile :Profile
    {
        public PacienteResponsableMapProfile() {
            CreateMap<PacienteResponsable, PacienteResponsableDto>()
                .ForMember(prdto => prdto.Paciente, opts => opts.MapFrom(pr => pr.Paciente))
                .ForMember(prdto => prdto.Responsable, opts => opts.MapFrom(pr => pr.Responsable))
                .ReverseMap();
            CreateMap<PacienteResponsable, PacienteMiResponsableDto>()
                .ForMember(prdto => prdto.Responsable, opts => opts.MapFrom(pr => pr.Responsable))
                .ReverseMap();
        }
    }
}
