namespace InDoorMappingAPI.DTOs.PUTs
{
    public class PutInfraestruturaDTO
    {
        public int Id { get; set; }
        public long TipoInfraestruturaId { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Piso { get; set; }
        public bool Acessivel { get; set; }
    }
}
