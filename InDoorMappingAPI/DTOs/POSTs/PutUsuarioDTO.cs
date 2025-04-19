using System.ComponentModel.DataAnnotations;

namespace IndoorMappingAPI.DTOs.POSTs
{
    public class PutUsuarioDTO
    {
        [Required]
        public string UsuarioId { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public long TipoUsuarioId { get; set; }

        public long MobilidadeId { get; set; }
    }
}
