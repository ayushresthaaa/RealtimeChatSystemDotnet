using Microsoft.EntityFrameworkCore; 
using MessagingPlatformBackend.Data;
using StudentRecordSystem.Data;
using StudentRecordSystem.Services.Interfaces; 
using StudentRecordSystem.Services.Implementations;
using Microsoft.AspNetCore.Identity;
using StudentRecordSystem.Data.Entities;
using StudentRecordSystem.Models;
using StudentRecordSystem.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //adds support for MVC controllers to handle HTTP requests and responses.
builder.Services.AddEndpointsApiExplorer(); //enables API endpoint exploration and documentation generation.
builder.Services.AddSwaggerGen(); //adds support for generating Swagger documentation for the API.

//database 
builder.Services.AddDbContext<StudentRecordDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // this is scoped, meaning a new instance of ChatDbContext will be created for each HTTP request and shared within that request. The UseNpgsql method configures the context to use PostgreSQL as the database provider, and it retrieves the connection string from the application's configuration settings (e.g., appsettings.json) under the key "DefaultConnection".
//options mean we are passing a lambda expression to configure the DbContext options. In this case, we are specifying that we want to use PostgreSQL as our database provider and providing the connection string from the configuration. This allows our application to connect to the PostgreSQL database when performing data operations through the ChatDbContext.
//npgsql means .net provider for the postgres database 

builder.Services.Configure<Student>(builder.Configuration.GetSection("Student")); //this line of code is used to bind the "Student" section of the application's configuration (e.g., appsettings.json) to a strongly-typed Student class. By doing this, you can easily access the configuration values related to the Student settings throughout your application by injecting the IOptions<Student> interface where needed. This allows for better organization and management of configuration settings specific to the Student entity.
//configure dependency injection for services
builder.Services.AddScoped<IModuleService, ModuleService>(); 
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<JwtService>(); 
//register identity framework 
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<StudentRecordDbContext>().AddDefaultTokenProviders(); 


//auth 
builder.Services.AddAuthentication(
    options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; 
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; 
        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme; 
    }
).AddJwtBearer(
    options =>
    {
        var jwtoptions = builder.Configuration.GetSection("jwt");
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true, 
            ValidIssuer = jwtoptions["Issuer"], 

            ValidateAudience = true, 
            ValidAudience = jwtoptions["Audience"], 

            ValidateIssuerSigningKey = true, 
            IssuerSigningKey  =  new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtoptions["SecretKey"]!)),

            ValidateLifetime = true, 
            
        };
    }
); 

builder.Services.AddCors(options =>
{
    // Development - open to all origins
    options.AddPolicy("Production", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();



//configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} //if the application is running in the development environment, it enables Swagger middleware to generate and serve the API documentation. The UseSwagger method generates the Swagger JSON document, while UseSwaggerUI provides a user-friendly interface to explore and test the API endpoints. This is typically only enabled in development to avoid exposing API documentation in production environments.

app.UseCors("all"); 
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

//health check endpoint
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));
using (var scope = app.Services.CreateScope())
{
	var db = scope.ServiceProvider.GetRequiredService<StudentRecordDbContext>();
	db.Database.Migrate();
}
app.Run();