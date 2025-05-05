namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetFeedbackCaminhoDTO
    {
        public long UsuarioId { get; set; }
        public long CaminhoId { get; set; }
        public int Avaliacao { get; set; } = 5; // default 5
        public string? Comentario { get; set; }
    }
}
