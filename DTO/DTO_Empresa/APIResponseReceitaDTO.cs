using System.Text.Json.Serialization;

namespace Localiza_Aplicattion.DTO.DTO_Empresa
{
    public class APIResponseReceitaDTO
    {
        [JsonPropertyName("nome")]
        public string NomeEmpresarial { get; set; } = string.Empty;

        [JsonPropertyName("fantasia")]
        public string? NomeFantasia { get; set; }

        [JsonPropertyName("cnpj")]
        public string Cnpj { get; set; } = string.Empty;

        [JsonPropertyName("situacao")]
        public string? Situacao { get; set; }

        [JsonPropertyName("abertura")]
        public string? Abertura { get; set; }

        [JsonPropertyName("tipo")]
        public string? Tipo { get; set; }

        [JsonPropertyName("natureza_juridica")]
        public string? NaturezaJuridica { get; set; }

        [JsonPropertyName("atividade_principal")]
        public List<ReceitaWsAtividadeDto>? AtividadePrincipal { get; set; }

        [JsonPropertyName("logradouro")]
        public string? Logradouro { get; set; }

        [JsonPropertyName("numero")]
        public string? Numero { get; set; }

        [JsonPropertyName("complemento")]
        public string? Complemento { get; set; }

        [JsonPropertyName("bairro")]
        public string? Bairro { get; set; }

        [JsonPropertyName("municipio")]
        public string? Municipio { get; set; }

        [JsonPropertyName("uf")]
        public string? Uf { get; set; }

        [JsonPropertyName("cep")]
        public string? Cep { get; set; }

        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("message")]
        public string? Message { get; set; } 
    }

    public class ReceitaWsAtividadeDto
    {
        [JsonPropertyName("text")]
        public string Text { get; set; } = string.Empty;

        [JsonPropertyName("code")]
        public string Code { get; set; } = string.Empty;
    }

}
