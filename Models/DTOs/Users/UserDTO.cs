namespace MessagingPlatformBackend.Models.DTOs.Users  { 

    public class UserDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DisplayName { get; set; } = string.Empty;
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public string Status { get; set; } = "offline";
        public DateTimeOffset CreatedAt { get; set; }
    }
} 