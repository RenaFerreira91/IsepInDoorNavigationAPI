namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostFeedbackCaminhoDTO
    {
        public int FeedbackId { get; set; }
        public long UsuarioId { get; set; }
        public long CaminhoId { get; set; }
        public int Avaliacao { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
