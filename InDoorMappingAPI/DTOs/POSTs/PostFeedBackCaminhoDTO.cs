namespace IndoorMappingAPI.DTOs.POSTs
{
    public class PostFeedbackCaminhoDTO
    {
        public long UsuarioId { get; set; }
        public long CaminhoId { get; set; }
        public int Avaliacao { get; set; }
        public string? Comentario { get; set; }
    }
}
