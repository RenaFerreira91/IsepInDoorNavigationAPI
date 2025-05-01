namespace InDoorMappingAPI.DTOs.PUTs
{
    public class PutUsuarioDTO
    {
        public long UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public int TipoUsuarioId { get; set; }
        public int MobilidadeId { get; set; }
    }

}
