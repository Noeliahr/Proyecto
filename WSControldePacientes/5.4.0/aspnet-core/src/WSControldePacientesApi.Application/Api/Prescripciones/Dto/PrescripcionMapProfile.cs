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
            CreateMap<Prescripcion, PrescripcionDto>().ReverseMap();
            CreateMap<Prescripcion, CreatePrescripcionDto>().ReverseMap();
        }
    }
}
