
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class PacienteMapProfile : Profile
    {
        public PacienteMapProfile()
        {
            CreateMap<Paciente, CreatePacienteDto>().ForMember(cp => cp.DatosPersonales, opts => opts.MapFrom(p => p.DatosPersonales))
                .ForMember(cp => cp.NumSeguridadSocial, opts => opts.MapFrom(p => p.NumSeguridadSocial))
                .ForMember(cp => cp.DatosTermometro, opts => opts.MapFrom(p => p.Termometro))
                .ForMember(cp => cp.FechaNacimiento, opts => opts.MapFrom(p => p.FechaNacimiento))
                .ForMember(cp => cp.Temperatura_Media, opts => opts.MapFrom(p => p.Temperatura_Media))
                .ForMember(cp => cp.Creador, opts => opts.MapFrom(p => p.MiMedicoCabecera))
                .ReverseMap();



            CreateMap<Paciente, PacienteDto>().ForMember(pa => pa.datosPersonales, opts => opts.MapFrom(p => p.DatosPersonales))
                .ForMember(pa => pa.termometroDto, opts => opts.MapFrom(p => p.Termometro));

            CreateMap<PacienteDto, Paciente>().ForMember(p => p.DatosPersonales, opts => opts.MapFrom(pa => pa.datosPersonales))
                .ForMember(p => p.Termometro, opts => opts.MapFrom(pa => pa.termometroDto));

            //CreateMap<Paciente, MisMedicosDto>().ForMember(mmedico=> mmedico.NumSeguridadSocial, opts=> opts.MapFrom(paciente=>paciente.NumSeguridadSocial))
            //    .ForMember(mmedico=>mmedico.misMedicos, opts => opts.MapFrom(paciente => paciente.MisMedicos));

            CreateMap<Paciente, MisResponsables>().ForMember(res => res.Responsables, opts => opts.MapFrom(pac => pac.MisResponsables))
                .ForMember(res => res.NumSeguridadSocial, opts => opts.MapFrom(pac => pac.NumSeguridadSocial));

            CreateMap<Paciente, MisEnfermedades>().ForMember(menf => menf.NumSeguridadSocial, opts => opts.MapFrom(paciente => paciente.NumSeguridadSocial))
                .ForMember(menf => menf.enfermedadPacientes, opts => opts.MapFrom(paciente => paciente.MisEnfermedades));

            //CreateMap<Paciente, MisDirecciones>().ForMember(dir => dir.direcciones, opts => opts.MapFrom(pa => pa.Persona.Ubicaciones))
            //    .ForMember(dir => dir.NumSeguridadSocial, opts => opts.MapFrom(pa => pa.NumSeguridadSocial));

            CreateMap<Paciente, MiEvolucionTemperatura>().ForMember(met => met.Control_de_Temperatura, opts => opts.MapFrom(pa => pa.Control_de_Temperatura));
        }
    }
}
