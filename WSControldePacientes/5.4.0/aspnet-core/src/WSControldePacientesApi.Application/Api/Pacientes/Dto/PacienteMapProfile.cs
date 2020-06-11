﻿
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.Api.Pacientes.Dto;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class PacienteMapProfile : Profile
    {
        public PacienteMapProfile()
        {
            CreateMap<Paciente, CreatePacienteDto>().ReverseMap();

            CreateMap<Paciente, EditPacienteDto>().ReverseMap();

            CreateMap<Paciente, PacienteDto>().ForMember(pmrdto => pmrdto.DatosPersonalesUserName, opts => opts.MapFrom(pr => pr.DatosPersonales.UserName))
                .ForMember(pmrdto => pmrdto.DatosPersonalesName, opts => opts.MapFrom(pr => pr.DatosPersonales.Name))
                .ForMember(pmrdto => pmrdto.DatosPersonalesSurname, opts => opts.MapFrom(pr => pr.DatosPersonales.Surname))
                .ForMember(pmrdto => pmrdto.DatosPersonalesEmailAddress, opts => opts.MapFrom(pr => pr.DatosPersonales.EmailAddress))
                .ForMember(pmrdto => pmrdto.DatosPersonalesTelefono, opts => opts.MapFrom(pr => pr.DatosPersonales.Telefono))
                .ForMember(pmrdto => pmrdto.NumSeguridadSocial, opts => opts.MapFrom(p => p.NumSeguridadSocial))
                .ForMember(p => p.FechaNacimiento, opts => opts.MapFrom(p => p.FechaNacimiento))
                .ReverseMap();

            CreateMap<Paciente, MisResponsables>().ForMember(res => res.Responsables, opts => opts.MapFrom(pac => pac.MisResponsables))
                .ForMember(res => res.NumSeguridadSocial, opts => opts.MapFrom(pac => pac.NumSeguridadSocial)).ReverseMap();

            CreateMap<Paciente, MiEvolucionTemperatura>().ForMember(met => met.Control_de_Temperatura, opts => opts.MapFrom(pa => pa.ControlTemperatura));
        
            CreateMap<Paciente,PacienteCompletoDto>()
                .ForMember(p=> p.total_responsables, opts=> opts.MapFrom(p=> p.MisResponsables.Count >0 ? p.MisResponsables.Count : 0))
                .ReverseMap();

            CreateMap<User, UserNameMedicosCabecera>().ForMember(u => u.UserName, opts => opts.MapFrom(u => u.UserName)).ReverseMap();




            CreateMap<Paciente, MisEnfermedades>().ReverseMap();
            CreateMap<Paciente, MisPrescripciones>().ReverseMap();
            CreateMap<Paciente, MisRecordatorios>()
                .ForMember(p => p.recordatorios, opts=> opts.MapFrom(p=> p.MisRecordatorios))
                .ReverseMap();
        }
    }
}
