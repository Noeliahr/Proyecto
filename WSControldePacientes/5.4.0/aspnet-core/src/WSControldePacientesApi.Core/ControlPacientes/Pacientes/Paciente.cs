using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using WSControldePacientesApi.Authorization.Users;
using WSControldePacientesApi.ControlPacientes.Citas;
using WSControldePacientesApi.ControlPacientes.Direcciones;
using WSControldePacientesApi.ControlPacientes.EnfermadesPacientes;
using WSControldePacientesApi.ControlPacientes.Medicos;
using WSControldePacientesApi.ControlPacientes.PacientesResponsables;
using WSControldePacientesApi.ControlPacientes.Prescripciones;
using WSControldePacientesApi.ControlPacientes.ControlTemperaturas;
using WSControldePacientesApi.ControlPacientes.Recordatorios;

namespace WSControldePacientesApi.ControlPacientes.Pacientes
{
    public class Paciente : FullAuditedEntity
    {
        [Required]
        public long DatosPersonalesId { get; set; }

        [ForeignKey(nameof(DatosPersonalesId))]
        public User DatosPersonales { get; set; }

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public long NumSeguridadSocial { get; set; }

        [Required]
        public int DondeViveId { get; set; }
        [Required]
        public Direccion DondeVive { get; set; }

        public int MiMedicoCabeceraId { get; set; }

        public Medico MiMedicoCabecera { get; set; }

        public ICollection<EnfermedadPaciente> MisEnfermedades { get; set; }

        public ICollection<Cita> MisCitasMedicas { get; set; }

        public ICollection<PacienteResponsable> MisResponsables { get; set; }

        public ICollection<Prescripcion> MisPrescripciones { get; set; }

        public ICollection<Recordatorio> MisRecordatorios { get; set; }

        public ICollection<ControlTemperatura> ControlTemperatura { get; set; }

    }
}
