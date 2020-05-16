using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.ControlesTemperaturas.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class MiEvolucionTemperatura : EntityDto
    {
        public ICollection<ControlTemperaturaDto> Control_de_Temperatura { get; set; }
    }
}
