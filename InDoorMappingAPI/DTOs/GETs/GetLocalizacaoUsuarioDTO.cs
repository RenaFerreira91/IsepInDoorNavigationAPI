namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetLocalizacaoUsuarioDTO
    {
        public long Id { get; set; }
        public long UsuarioId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime DataHora { get; set; }
    }
}
