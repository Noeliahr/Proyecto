using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Direcciones;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.ControlPacientes.Citas
{
    public class Cita : FullAuditedEntity
    {
        [Required]
        public Paciente Paciente { get; set; }
        public int PacienteId { get; set; }

        [Required]
        public Medico Medico { get; set; }
        public int MedicoId { get; set; }

        [Required]
        public DateTime FechaHora { get; set; }

        [Required]
        public Direccion Direccion { get; set; }

        public string Consulta { get; set; }

        public string Servicio_Especialidad {get; set;}

        public string Centro { get; set; }

    }
}
