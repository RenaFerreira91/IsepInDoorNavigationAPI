namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminhoDetalhadoDTO
    {
        public long Id { get; set; }
        public long OrigemId { get; set; }
        public string OrigemDescricao { get; set; }
        public int OrigemPiso { get; set; }
        public string OrigemTipoInfraestrutura { get; set; }

        public long DestinoId { get; set; }
        public string DestinoDescricao { get; set; }
        public int DestinoPiso { get; set; }
        public string DestinoTipoInfraestrutura { get; set; }

        public double Distancia { get; set; }
        public bool Acessivel { get; set; }
        public string TipoAcessibilidade { get; set; }
    }
}
