namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostInfraestruturaDTO
    {
        public long TipoInfraestruturaId { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int Piso { get; set; }
        public bool Acessivel { get; set; }
    }
}
