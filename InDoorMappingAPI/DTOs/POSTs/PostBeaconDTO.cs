namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostBeaconDTO
    {
        public string Nome { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Localizacao { get; set; }
        public int Piso { get; set; }
    }
}
