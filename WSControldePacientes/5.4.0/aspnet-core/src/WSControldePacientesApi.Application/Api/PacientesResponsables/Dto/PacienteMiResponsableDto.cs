using Abp.Authorization.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.Api.Responsables.Dto;
using WSControlPacientesApi.ControlPacienteApi.Responsables.Dto;

namespace WSControlPacientesApi.ControlPacienteApi.PacientesResponsables.Dto
{
    public class PacienteMiResponsableDto 
    {
        public ResponsableDto responsable { get; set; }
        
    }
}
