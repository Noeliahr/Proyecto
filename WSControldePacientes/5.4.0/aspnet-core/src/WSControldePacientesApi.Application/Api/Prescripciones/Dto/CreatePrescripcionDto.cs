using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Prescripciones.Dto
{
    public class CreatePrescripcionDto :EntityDto
    {

        public int MedicamentoId { get; set; }

        public string Dosis { get; set; }

        public DateTime Fecha_Inicio { get; set; }

        public DateTime Fecha_Final { get; set; }

        public string Como_Tomar { get; set; }
    }
}
