namespace IndoorMappingAPI.DTOs.POSTs
{
    public class PostComandoEpocDTO
    {
        public long UsuarioId { get; set; }
        public string Comando { get; set; }
        public double Intensidade { get; set; }
    }
}
