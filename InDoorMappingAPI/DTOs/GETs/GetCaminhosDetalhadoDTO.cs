namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminhosDetalhadoDTO
    {
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }
        public List<List<GetCaminhoDetalhadoDTO>> Caminhos { get; set; } = new();
    }
}
