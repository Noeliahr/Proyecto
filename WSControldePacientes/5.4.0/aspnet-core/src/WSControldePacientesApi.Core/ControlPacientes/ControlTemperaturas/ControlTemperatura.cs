using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Pacientes;

namespace WSControldePacientesApi.ControlPacientes.ControlTemperaturas
{
    public class ControlTemperatura : FullAuditedEntity
    {
        public Paciente Paciente { get; set; }

        public int PacienteId { get; set; }

        public decimal Temperatura { get; set; }

        public DateTime Fecha { get; set; }
    }
}
