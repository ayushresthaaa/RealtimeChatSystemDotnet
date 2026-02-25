using System.ComponentModel.DataAnnotations;
using MessagingPlatformBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class practiceDbContext: DbContext
{
    public DbSet<User> Users {get; set;}

    public practiceDbContext(DbContextOptions<practiceDbContext> options) : base(options)
    {

    }

}