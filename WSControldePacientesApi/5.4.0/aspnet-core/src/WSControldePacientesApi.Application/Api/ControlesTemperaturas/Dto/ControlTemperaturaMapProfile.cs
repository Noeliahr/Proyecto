using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.TemperaturasPacientes;

namespace WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto
{
    public class ControlTemperaturaMapProfile : Profile
    {
        public ControlTemperaturaMapProfile()
        {
            CreateMap<TemperaturaPaciente, ControlTemperaturaDto>().ForMember(CT => CT.Temperatura, opts => opts.MapFrom(TP => TP.Temperatura))
                .ForMember(CT => CT.Fecha, opts => opts.MapFrom(TP => TP.Fecha));
        }
    }
}
