using System.ComponentModel.DataAnnotations;

namespace Localiza_Aplicattion.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(255)]
        public string SenhaHash { get; set; } = string.Empty;

        // Relação de 1 para N (Um usuário pode ter muitas empresas)
        public ICollection<Empresa> Empresas { get; set; } = new List<Empresa>();

    }
}
