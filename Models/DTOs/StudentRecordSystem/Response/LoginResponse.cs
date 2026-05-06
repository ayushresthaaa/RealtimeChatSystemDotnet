namespace StudentRecordSystem.Models.DTO
{
    public class LoginResponse
    {
        public bool Success  {get; set; }
        public string? Message {get; set; }
        public string? Token {get; set; }
        
    }
}