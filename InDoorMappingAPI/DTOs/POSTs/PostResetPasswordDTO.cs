namespace InDoorMappingAPI.DTOs.POSTs
{
    public class PostResetPasswordDTO
    {
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
}
