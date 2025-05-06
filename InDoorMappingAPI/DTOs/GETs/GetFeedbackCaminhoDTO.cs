namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetFeedbackCaminhoDTO
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public long CaminhoId { get; set; }
        public int Avaliacao { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
