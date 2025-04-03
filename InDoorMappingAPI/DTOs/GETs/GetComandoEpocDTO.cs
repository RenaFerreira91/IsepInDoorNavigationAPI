namespace InDoorMappingAPI.DTOs.GETs
{
    public class GetComandoEpocDTO
    {
        public int ComandoId { get; set; }
        public string UsuarioNome { get; set; }
        public string Comando { get; set; }
        public double Intensidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
