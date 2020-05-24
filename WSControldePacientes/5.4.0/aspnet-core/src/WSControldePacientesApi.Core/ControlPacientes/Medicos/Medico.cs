using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Citas;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.ControlPacientes.Medicos
{
    public class Medico : FullAuditedEntity
    {
        [Required]
        public long DatosPersonalesId { get; set; }

        [ForeignKey(nameof(DatosPersonalesId))]
        public User DatosPersonales { get; set; }

        [Required]
        public string Especialidad { get; set; }

        public ICollection<Paciente> MisPacientes { get; set; }

        public ICollection<Cita> Agenda { get; set; }
    }
}
