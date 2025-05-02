namespace InDoorMappingAPI.DTOs.PUTs
{
    public class PutBeaconDTO
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Localizacao { get; set; }
    }
}
