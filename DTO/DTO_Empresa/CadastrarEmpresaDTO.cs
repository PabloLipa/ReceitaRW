using System.ComponentModel.DataAnnotations;

namespace Localiza_Aplicattion.DTO.DTO_Empresa
{
    public class CadastrarEmpresaDTO
    {
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [StringLength(18, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter entre 14 e 18 caracteres.")]
        public string Cnpj { get; set; } = string.Empty;
    }
}
