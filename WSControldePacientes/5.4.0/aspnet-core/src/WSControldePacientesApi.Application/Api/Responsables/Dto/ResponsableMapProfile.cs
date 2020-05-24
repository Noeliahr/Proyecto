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
            CreateMap<Responsable, ResponsableDto>().ForMember(pmrdto => pmrdto.ResponsableDatosPersonalesUserName, opts => opts.MapFrom(pr => pr.DatosPersonales.UserName))
                .ForMember(pmrdto => pmrdto.ResponsableDatosPersonalesName, opts => opts.MapFrom(pr => pr.DatosPersonales.Name))
                .ForMember(pmrdto => pmrdto.ResponsableDatosPersonalesSurname, opts => opts.MapFrom(pr => pr.DatosPersonales.Surname))
                .ForMember(pmrdto => pmrdto.ResponsableDatosPersonalesEmailAddress, opts => opts.MapFrom(pr => pr.DatosPersonales.EmailAddress))
                .ForMember(pmrdto => pmrdto.ResponsableDatosPersonalesTelefono, opts => opts.MapFrom(pr => pr.DatosPersonales.Telefono))
                .ReverseMap();

            CreateMap<Responsable, DatosResponsableDto>()
                .ForMember(rspdto => rspdto.DatosPersonales, opts => opts.MapFrom(rsp => rsp.DatosPersonales))
                .ReverseMap();

  
        }
    }
}
