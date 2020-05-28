using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.PacientesResponsables;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;

namespace WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto
{
    public class PacienteResponsableMapProfile :Profile
    {
        public PacienteResponsableMapProfile() {
            CreateMap<PacienteResponsable, PacienteResponsableDto>()
                .ForMember(prdto => prdto.paciente, opts => opts.MapFrom(pr => pr.Paciente))
                .ForMember(prdto => prdto.responsable, opts => opts.MapFrom(pr => pr.Responsable))
                .ReverseMap();
            CreateMap<PacienteResponsable, PacienteMiResponsableDto>().ForMember(pmr => pmr.responsable, opts => opts.MapFrom(pr => pr.Responsable)).ReverseMap();
               
        }
    }
}
