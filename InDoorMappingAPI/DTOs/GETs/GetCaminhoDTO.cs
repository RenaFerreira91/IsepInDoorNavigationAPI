namespace IndoorMappingAPI.DTOs.GETs
{
    public class GetCaminhoDTO
    {
        public long CaminhoId { get; set; }
        public long OrigemBeaconId { get; set; }
        public long DestinoBeaconId { get; set; }
        public string OrigemNome { get; set; }
        public string DestinoNome { get; set; }
        public float Distancia { get; set; }
        public bool Acessivel { get; set; }
        public string? AcessibilidadeDescricao { get; set; }
    }
}

