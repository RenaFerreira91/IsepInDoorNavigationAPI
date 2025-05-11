namespace InDoorMappingAPI.DTOs.PUTs
{
    public class PutFeedbackForUserDTO
    {
        public long Id { get; set; }
        public long FeedbackId { get; set; }
        public long UsuarioId { get; set; }
        public long AdminId { get; set; }
        public string Comentario { get; set; }
    }
}
