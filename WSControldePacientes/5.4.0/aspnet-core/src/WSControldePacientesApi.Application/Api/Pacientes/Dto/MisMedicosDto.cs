using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControlPacientesApi.ControlPacienteApi.Medicos.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.Pacientes.Dto
{
    public class MisMedicosDto : EntityDto
    {
        public long NumSeguridadSocial { get; set; }
        public MedicoDto misMedicos { get; set; }
    }
}
