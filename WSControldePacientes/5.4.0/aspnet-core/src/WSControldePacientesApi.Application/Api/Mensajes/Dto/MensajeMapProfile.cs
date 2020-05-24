using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Mensajes;

namespace WSControldePacientesApi.Api.Mensajes.Dto
{
    public class MensajeMapProfile : Profile
    {
        public MensajeMapProfile()
        {
            CreateMap<Mensaje, CreateMensajeDto>().ReverseMap();
            CreateMap<Mensaje, MensajeDto>().ReverseMap();
        }
    }
}
