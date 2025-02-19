﻿using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WSControldePacientesApi.ControlPacientes.Prescripciones;

namespace WSControldePacientesApi.ControlPacientes.Medicamentos
{
    public class Medicamento : FullAuditedEntity
    {
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Tipo { get; set; }
        [Required]
        public string Gramaje { get; set; }
        [Required]
        public string Funcionalidad { get; set; }
        [Required]
        public string ComponenteBase { get; set; }


        public ICollection<Prescripcion> prescripciones { get; set; }
    }
}
