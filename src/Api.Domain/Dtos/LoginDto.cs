using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail está com formato inválido.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "E-mail deve ter no mínimo 5 e no máximo 100 caracteres.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password é um campo obrigatório.")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Password deve ter no mínimo 4 e no máximo 20 caracteres.")]
        public string Password { get; set; }
    }
}
