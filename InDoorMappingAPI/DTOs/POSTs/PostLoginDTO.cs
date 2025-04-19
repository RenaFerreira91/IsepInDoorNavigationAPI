using System.ComponentModel.DataAnnotations;

namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostLoginDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
