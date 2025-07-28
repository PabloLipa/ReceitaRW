using System.ComponentModel.DataAnnotations;

namespace Localiza_Aplicattion.DTO.DTO_Usuario
{
    public class LogInDTO
    {
        
        [Required(ErrorMessage = "O email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de email inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Senha { get; set; } = string.Empty;
    }
}
