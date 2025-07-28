using Localiza_Aplicattion.DTO.DTO_Empresa;

namespace Localiza_Aplicattion.Interfaces
{
    public interface IReceitaService
    {
        Task<APIResponseReceitaDTO?> ConsultarCnpj(string cnpj);
    }
}
