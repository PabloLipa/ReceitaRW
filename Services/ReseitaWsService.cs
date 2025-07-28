using Localiza_Aplicattion.DTO.DTO_Empresa;
using Localiza_Aplicattion.Interfaces;
using System.Text.Json;

namespace Localiza_Aplicattion.Services
{
    public class ReceitaWsService : IReceitaService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://www.receitaws.com.br/v1/cnpj/";

        public ReceitaWsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<APIResponseReceitaDTO?> ConsultarCnpj(string cnpj)
        {
            
            string cleanCnpj = new string(cnpj.Where(char.IsDigit).ToArray());

            if (cleanCnpj.Length != 14)
            {
                return new APIResponseReceitaDTO { Status = "ERROR", Message = "CNPJ deve ter 14 dígitos numéricos." };
            }

            var response = await _httpClient.GetAsync($"{BaseUrl}{cleanCnpj}");

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var receitaWsResponse = JsonSerializer.Deserialize<APIResponseReceitaDTO>(content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                
                if (receitaWsResponse?.Status == "ERROR")
                {
                    return new APIResponseReceitaDTO { Status = "ERROR", Message = receitaWsResponse.Message ?? "Erro desconhecido da API da ReceitaWS." };
                }

                return receitaWsResponse;
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                return new APIResponseReceitaDTO { Status = "ERROR", Message = "Limite de requisições excedido para a ReceitaWS. Tente novamente mais tarde." };
            }
            else
            {
                return new APIResponseReceitaDTO { Status = "ERROR", Message = $"Erro ao consultar CNPJ na ReceitaWS: {response.StatusCode} - {response.ReasonPhrase}" };
            }
        }
    }
}
