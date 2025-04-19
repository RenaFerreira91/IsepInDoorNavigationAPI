namespace IndoorMappingAPI.DTOs.GETs
{
    public class GetUsuarioDTO
    {
        public string UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string? MobilidadeTipo { get; set; } // ve de Mobilidade.Tipo
        public string? TipoUsuario { get; set; } // vem de TipoUsuario.Tipo


    }
}
