namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetInfraestruturaDTO
    {
        public long InfraestruturaId { get; set; }

        public string? Descricao { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Piso { get; set; }

        public bool Acessivel { get; set; }

        public string Tipo { get; set; } = string.Empty;
    }
}
