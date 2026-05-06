using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace StudentRecordSystem.Data;

public class StudentRecordDbContextFactory : IDesignTimeDbContextFactory<StudentRecordDbContext>
{
    public StudentRecordDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<StudentRecordDbContext>();
        
        optionsBuilder.UseNpgsql("Host=localhost;Port=5434;Database=chatdb;Username=postgres;Password=postgres");
        
        return new StudentRecordDbContext(optionsBuilder.Options);
    }
}