namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetCaminho2DTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }
        public int? Piso { get; set; }
        public bool Acessivel { get; set; }
        public string ListaCoordenadas { get; set; }  // WKT ou GeoJSON string
    }
}
