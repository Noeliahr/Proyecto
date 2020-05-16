using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Personas.Dto;
using WSControlPacientesApi.ControlPacienteApi.Ubicaciones.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class MisDirecciones : EntityDto
    {
        public long NumSeguridadSocial { get; set; }

        //public PersonaDireccionDto Donde_Vive {get; set;}

        public ICollection<UbicacionDto> direcciones { get; set; }

    }
}
