using Localiza_Aplicattion.DTO.DTO_Usuario;
using Localiza_Aplicattion.Models;

namespace Localiza_Aplicattion.Interfaces
{
    public interface IAutencticaService
    {

        Task<Usuario?> Register(RegistroDTO registerDto);
        Task<LogInResponseDTO?> Login(LogInDTO loginDto);
    }
}
