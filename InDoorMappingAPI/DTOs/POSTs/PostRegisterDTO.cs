
using System.ComponentModel.DataAnnotations;

namespace IndoorMappingAPI.DTOs.POSTs
{
    public class PostRegisterDTO
    {
        [Required]
        public string Nome { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public int TipoId { get; set; } = 4; // 1-Admin, 2-Editor, 3-Reader, 4-User
        public int MobilidadeId { get; set; } = 1;
    }
}
