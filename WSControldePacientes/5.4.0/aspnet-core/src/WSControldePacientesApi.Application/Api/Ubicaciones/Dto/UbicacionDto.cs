using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Direcciones.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Ubicaciones.Dto
{
    public class UbicacionDto : EntityDto
    {
        public DireccionDto direccion { get; set; }
    }
}
