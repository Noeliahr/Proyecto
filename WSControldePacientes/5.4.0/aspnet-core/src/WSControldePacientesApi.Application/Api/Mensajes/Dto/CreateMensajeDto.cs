using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WSControldePacientesApi.Api.Mensajes.Dto
{
    public class CreateMensajeDto
    {
        [Required]
        public string PersonaDestinoUserName { get; set; }
        [Required]
        [MaxLength(120)]
        public string Texto { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
    }
}
