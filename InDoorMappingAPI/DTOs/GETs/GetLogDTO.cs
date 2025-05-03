namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetLogDTO
    {
        public long Id { get; set; }
        public long? UsuarioId { get; set; }
        public string Acao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
