namespace InDoorMappingAPI.DTOs.PUTs
{
    public class PutCaminho2DTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public long OrigemId { get; set; }
        public long DestinoId { get; set; }
        public int? Piso { get; set; }
        public bool Acessivel { get; set; }
        public string ListaCoordenadas { get; set; }
    }
}
