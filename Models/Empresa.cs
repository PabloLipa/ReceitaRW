using System.ComponentModel.DataAnnotations;

namespace Localiza_Aplicattion.Models
{
    public class Empresa
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string NomeEmpresarial { get; set; } = string.Empty;

        [StringLength(200)]
        public string? NomeFantasia { get; set; }

        [Required]
        [StringLength(18)]
        public string Cnpj { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Situacao { get; set; }

        [StringLength(20)]
        public string? Abertura { get; set; }

        [StringLength(50)]
        public string? Tipo { get; set; }

        [StringLength(200)]
        public string? NaturezaJuridica { get; set; }

        [StringLength(500)]
        public string? AtividadePrincipal { get; set; }

        [StringLength(200)]
        public string? Logradouro { get; set; }

        [StringLength(50)]
        public string? Numero { get; set; }

        [StringLength(100)]
        public string? Complemento { get; set; }

        [StringLength(100)]
        public string? Bairro { get; set; }

        [StringLength(100)]
        public string? Municipio { get; set; }

        [StringLength(2)]
        public string? Uf { get; set; }

        [StringLength(10)]
        public string? Cep { get; set; }

        


        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; } = default!;
    }
}
