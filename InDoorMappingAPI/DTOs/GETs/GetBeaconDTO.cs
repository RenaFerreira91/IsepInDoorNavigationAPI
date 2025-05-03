namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetBeaconDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Localizacao { get; set; }
        public int Piso { get; set; }
    }
}
