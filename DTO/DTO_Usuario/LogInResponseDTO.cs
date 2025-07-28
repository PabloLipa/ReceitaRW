namespace Localiza_Aplicattion.DTO.DTO_Usuario
{
    public class LogInResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public int UserId { get; set; }
        public string UserName { get; set; } = string.Empty;
    }
}
