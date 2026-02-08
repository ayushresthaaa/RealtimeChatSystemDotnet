using System.ComponentModel.DataAnnotations;//this is for data annotations like [Key], [Required], etc. that we will use to define our entity properties and their constraints.
namespace MessagingPlatformBackend.Models.Entities
{
    public class User
    {   
        public Guid Id { get; set; } // Unique identifier for the user

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; } = string.Empty;  // Username of the user    
        
        [Required]
        [EmailAddress]
        [StringLength(200)]
        public string Email { get; set; } = string.Empty; // Email address of the user

        [Required]
        public string PasswordHash { get; set; } = string.Empty; // Hashed password for authentication

        [StringLength(100)]
        public string? DisplayName { get; set; } // Optional display name for the user
        public string? AvatarUrl { get; set; }
        public string? Bio { get; set; }
        public string Status { get; set; } = "offline";
        public DateTimeOffset? LastSeenAt { get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow; //date time offset means it can store both the date and time along with the offset from UTC, which is useful for handling time zones in a global application. The default value is set to the current UTC time when a new user is created.
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public bool IsDeleted { get; set; }
    }
}