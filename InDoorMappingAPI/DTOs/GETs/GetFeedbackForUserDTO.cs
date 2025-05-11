namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetFeedbackForUserDTO
    {
        public long Id { get; set; }
        public long FeedbackId { get; set; }
        public long UsuarioId { get; set; }
        public long AdminId { get; set; }
        public string? Comentario { get; set; }
        public DateTime DataHora { get; set; }
    }
}
