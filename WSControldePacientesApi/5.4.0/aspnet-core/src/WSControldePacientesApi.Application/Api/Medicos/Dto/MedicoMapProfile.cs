//using ApiControldePacientes.ControlPacientes.Medicos;
//using AutoMapper;
//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace WSControlPacientesApi.ControlPacienteApi.Medicos.Dto
//{
//    public class MedicoMapProfile : Profile
//    {
//        public MedicoMapProfile()
//        {
//            CreateMap<Medico, MedicoDto>().ForMember(mdto => mdto.personaDto, opt=> opt.MapFrom(m=> m.Persona))
//                .ForMember(mdto=> mdto.Especialidad, opt=> opt.MapFrom(m=> m.Especialidad))
//                .ReverseMap();
//        }
//    }
//}
