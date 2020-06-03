using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Mensajes.Dto
{
    public class MensajeSimple
    {
        public long personaId { get; set; }
        
        public string personaUserName { get; set; }

        public DateTime fechaHora { get; set; }

        public string Texto { get; set; }
    }
}
