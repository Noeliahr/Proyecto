using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Prescripciones;

namespace WSControldePacientesApi.Api.Prescripciones.Dto
{
    class PrescripcionMapProfile : Profile
    {
        public PrescripcionMapProfile()
        {
            CreateMap<Prescripcion, PrescripcionDto>()
                .ForMember(p=> p.isManana, opts=> opts.Ignore())
                .ForMember(p => p.isTarde, opts => opts.Ignore())
                .ForMember(p => p.isNoche, opts => opts.Ignore())
                .ReverseMap();
            CreateMap<Prescripcion, CreatePrescripcionDto>().ReverseMap();
        }
    }
}
