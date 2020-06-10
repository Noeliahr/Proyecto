using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Medicamentos;

namespace WSControldePacientesApi.Api.Medicamentos.Dto
{
    class MedicamentoMapProfile: Profile
    {
        public MedicamentoMapProfile()
        {
            CreateMap<Medicamento, MedicamentoDto>().ReverseMap();
        }
    }
}
