using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace WSControldePacientesApi.Api.Mensajes.Dto
{
    public class MensajeDto : EntityDto
    {
        public string PersonaOrigenUserName { get; set; }

        public string PersonaDestinoUserName { get; set; }

        public string Texto { get; set; }

        public DateTime Fecha { get; set; }

        public bool isLeido { get; set; }

        public bool isRecibido { get; set; }
    }

}
