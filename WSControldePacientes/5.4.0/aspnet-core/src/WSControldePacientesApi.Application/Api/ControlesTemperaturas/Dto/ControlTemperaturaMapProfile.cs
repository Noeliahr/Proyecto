using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;

namespace WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto
{
    public class ControlTemperaturaMapProfile : Profile
    {
        public ControlTemperaturaMapProfile()
        {
            CreateMap<ControlTemperatura, ControlTemperaturaDto>().ForMember(CT => CT.Temperatura, opts => opts.MapFrom(TP => TP.Temperatura))
                .ForMember(CT => CT.Fecha, opts => opts.MapFrom(TP => TP.Fecha));
        }
    }
}
