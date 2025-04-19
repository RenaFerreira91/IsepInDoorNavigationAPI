namespace IndoorMappingAPI.DTOs.GETs
{
    public class GetInfraestruturaDTO
    {
        public int InfraestruturaId { get; set; }
        public string Tipo { get; set; }
        public string Descricao { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Piso { get; set; }
        public bool Acessivel { get; set; }
    }
}
