using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostUsuarioDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Tipo { get; set; }

        public long MobilidadeId { get; set; } = 1;
    }
}
