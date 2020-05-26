using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControldePacientesApi.ControlPacientes.Responsables;

namespace WSControlPacientesApi.ControlPacienteApi.Responsables.Dto
{
    public class ResponsableMapProfile : Profile
    {
        public ResponsableMapProfile()
        {
            CreateMap<Responsable, ResponsableDto>().ForMember(pmrdto => pmrdto.DatosPersonalesUserName, opts => opts.MapFrom(pr => pr.DatosPersonales.UserName))
                .ForMember(pmrdto => pmrdto.DatosPersonalesName, opts => opts.MapFrom(pr => pr.DatosPersonales.Name))
                .ForMember(pmrdto => pmrdto.DatosPersonalesSurname, opts => opts.MapFrom(pr => pr.DatosPersonales.Surname))
                .ForMember(pmrdto => pmrdto.DatosPersonalesEmailAddress, opts => opts.MapFrom(pr => pr.DatosPersonales.EmailAddress))
                .ForMember(pmrdto => pmrdto.DatosPersonalesTelefono, opts => opts.MapFrom(pr => pr.DatosPersonales.Telefono))
                .ReverseMap();

            CreateMap<Responsable, DatosResponsableDto>()
                .ForMember(rspdto => rspdto.DatosPersonales, opts => opts.MapFrom(rsp => rsp.DatosPersonales))
                .ReverseMap();

  
        }
    }
}
