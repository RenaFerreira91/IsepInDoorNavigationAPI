namespace IndoorMappingAPI.DTOs.GETs
{
    public class GetFeedbackCaminhoDTO
    {
        public int FeedbackId { get; set; }
        public string UsuarioNome { get; set; }
        public long CaminhoId { get; set; }
        public int Avaliacao { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
