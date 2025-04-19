namespace IndoorMappingAPI.DTOs.POSTs
{
    public class PostDiarioDTO
    {
        public long UsuarioId { get; set; }
        public string Tipo { get; set; } // Ex: "texto"
        public string Conteudo { get; set; }
    }
}
