using System.ComponentModel.DataAnnotations;
using MessagingPlatformBackend.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagingPlatformBackend.Data
{   
    //db context is a class that derives from DbContext and represents a session with the database, allowing us to query and save data. It contains DbSet properties for each entity in our model, which correspond to tables in the database. In this case, we will have a DbSet<User> property to manage user entities.
    public class ChatDbContext : DbContext
    {
        public ChatDbContext(DbContextOptions<ChatDbContext> options) : base(options)
        {
                //this needs object during dependency injection, so we are passing it through the constructor and calling the base constructor of DbContext with the options parameter. This allows us to configure the DbContext with the necessary options, such as the database provider and connection string, when we register it in the dependency injection container in Program.cs.
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<User> Users { get; set; } // DbSet for managing User entities in the database
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the User entity
            modelBuilder.Entity<User>(entity=>
            {   
                entity.HasKey(u=>u.Id); 
                entity.HasIndex(u=> u.Username).IsUnique();
                entity.HasIndex(u=> u.Email).IsUnique();
                entity.Property(u=> u.Username).IsRequired().HasMaxLength(50);
                entity.Property(u=> u.Email).IsRequired().HasMaxLength(200);
            });
        }

    }
}