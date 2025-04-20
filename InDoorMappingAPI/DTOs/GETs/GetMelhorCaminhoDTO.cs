namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetMelhorCaminhoDTO
    {
        public List<long> InfraestruturasIds { get; set; }
        public bool UsouEntradaAlternativa { get; set; }
        public string Mensagem { get; set; }
    }
}

