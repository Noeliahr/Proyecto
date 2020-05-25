
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

            CreateMap<Paciente, PacienteDto>().ForMember(pa => pa.datosPersonales, opts => opts.MapFrom(p => p.DatosPersonales));


            CreateMap<PacienteDto, Paciente>().ForMember(p => p.DatosPersonales, opts => opts.MapFrom(pa => pa.datosPersonales));

            CreateMap<Paciente, MisResponsables>().ForMember(res => res.Responsables, opts => opts.MapFrom(pac => pac.MisResponsables))
                .ForMember(res => res.NumSeguridadSocial, opts => opts.MapFrom(pac => pac.NumSeguridadSocial)).ReverseMap();

            CreateMap<Paciente, MisEnfermedades>().ForMember(menf => menf.NumSeguridadSocial, opts => opts.MapFrom(paciente => paciente.NumSeguridadSocial))
                .ForMember(menf => menf.enfermedadPacientes, opts => opts.MapFrom(paciente => paciente.MisEnfermedades));


            CreateMap<Paciente, MiEvolucionTemperatura>().ForMember(met => met.Control_de_Temperatura, opts => opts.MapFrom(pa => pa.ControlTemperatura));
        
            CreateMap<Paciente,PacienteCompletoDto>().ReverseMap();

            CreateMap<User, UserNameMedicosCabecera>().ForMember(u => u.UserName, opts => opts.MapFrom(u => u.UserName)).ReverseMap();
        }
    }
}
