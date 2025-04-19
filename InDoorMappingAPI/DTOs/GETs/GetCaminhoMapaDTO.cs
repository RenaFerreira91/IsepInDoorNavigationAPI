namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminhoMapaDTO
    {
        public long CaminhoId { get; set; }
        public double OrigemLatitude { get; set; }
        public double OrigemLongitude { get; set; }
        public double DestinoLatitude { get; set; }
        public double DestinoLongitude { get; set; }
        public float Distancia { get; set; }
        public bool Acessivel { get; set; }
    }
}
