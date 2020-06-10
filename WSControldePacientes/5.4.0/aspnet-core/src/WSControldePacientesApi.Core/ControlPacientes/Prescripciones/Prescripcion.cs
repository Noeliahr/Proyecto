using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Medicamentos;
using WSControldePacientesApi.ControlPacientes.Pacientes;
using WSControldePacientesApi.ControlPacientes.Recordatorios;

namespace WSControldePacientesApi.ControlPacientes.Prescripciones
{
    public class Prescripcion : FullAuditedEntity
    {
        [Required]
        public Medicamento Medicamento { get; set; }
        [Required]
        public int MedicamentoId { get; set; }

        [Required]
        public Paciente Paciente { get; set; }
        [Required]
        public int PacienteId { get; set; }

        [Required]
        public string Dosis { get; set; }

        [Required]
        public DateTime Fecha_Inicio { get; set; }

        [Required]
        public DateTime Fecha_Final { get; set; }

        [Required]
        public string Como_Tomar { get; set; }


    }
}
