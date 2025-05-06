namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostChangePasswordDTO
    {
        public string Email { get; set; } 
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
