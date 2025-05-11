namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostFeedbackForUserDTO
    {
        public long FeedbackId { get; set; }
        public long UsuarioId { get; set; }
        public long AdminId { get; set; }
        public string? Comentario { get; set; }
    }
}
