using System.ComponentModel.DataAnnotations;
namespace MessagingPlatformBackend.Models.DTOs.Auth
{   //DTO ensures validation and data integrity when receiving registration data from clients. It allows us to enforce rules such as required fields, string length limits, and other constraints on the incoming data, ensuring that only valid and well-formed data is processed by our application.
    public class RegisterRequest
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;  // The username of the user registering for the chat application
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;  // The email of the user registering for the chat application
        
        [Required]
        [StringLength(200, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;  // The password of the user registering for the chat application

        [StringLength(100)]
        public string? DisplayName { get; set; } = string.Empty;  // An optional display name for the user, which can be used in the chat application instead of the username
    }
}