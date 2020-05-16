//using ApiControldePacientes.ControlPacientes.Responsables;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace WSControlPacientesApi.ControlPacienteApi.Responsables.Dto
//{
//    public class ResponsableMapProfile : Profile
//    {
//        public ResponsableMapProfile() {
//            CreateMap<Responsable, ResponsableDto>().ForMember(rspdto => rspdto.personaDto, opts => opts.MapFrom(rsp => rsp.DatosPersonales));

//            CreateMap<ResponsableDto, Responsable>().ForMember(rsp => rsp.DatosPersonales, opts => opts.MapFrom(rspdto => rspdto.personaDto));

//        }
//    }
//}
