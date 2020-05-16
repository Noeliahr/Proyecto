using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Direcciones;

namespace WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto
{
    public class DireccionMapProfile : Profile
    {
        public DireccionMapProfile()
        {
            //CreateMap<Direccion, DireccionDto>().ForMember(di => di.Tipo, opts => opts.MapFrom(d => d.Tipo))
            //    .ForMember(di => di.Nombre, opts => opts.MapFrom(d => d.Nombre))
            //    .ForMember(di => di.Numero, opts => opts.MapFrom(d => d.Numero))
            //    .ForMember(di => di.Piso, opts => opts.MapFrom(d => d.Piso))
            //    .ForMember(di => di.Bloque, opts => opts.MapFrom(d => d.Bloque))
            //    .ForMember(di => di.Escalera, opts => opts.MapFrom(d => d.Escalera))
            //    .ForMember(di => di.Codigo_Postal, opts => opts.MapFrom(d => d.Codigo_Postal))
            //    .ForMember(di => di.Municipio, opts => opts.MapFrom(d => d.Municipio))
            //    .ForMember(di => di.Provincia, opts => opts.MapFrom(d => d.Provincia))
            //    .ReverseMap();

            CreateMap<Direccion, DireccionDto>().ReverseMap();
        }
    }
}
