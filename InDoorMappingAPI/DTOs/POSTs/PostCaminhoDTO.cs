namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostCaminhoDTO
    {
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }
        public double Distancia { get; set; }
        public bool Acessivel { get; set; }
        public long? AcessibilidadeId { get; set; }
    }
}
