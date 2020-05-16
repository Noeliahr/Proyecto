using System.ComponentModel.DataAnnotations;

namespace WSControldePacientesApi.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}