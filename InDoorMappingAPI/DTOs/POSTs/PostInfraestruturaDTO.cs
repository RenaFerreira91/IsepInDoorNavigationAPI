namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostInfraestruturaDTO
    {
        public int TipoInfraestruturaId { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Piso { get; set; }
        public bool Acessivel { get; set; }
    }
}
