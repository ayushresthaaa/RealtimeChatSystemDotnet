using Microsoft.EntityFrameworkCore; 
using MessagingPlatformBackend.Data; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers(); //adds support for MVC controllers to handle HTTP requests and responses.
builder.Services.AddEndpointsApiExplorer(); //enables API endpoint exploration and documentation generation.
builder.Services.AddSwaggerGen(); //adds support for generating Swagger documentation for the API.

//database 
builder.Services.AddDbContext<ChatDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); // this is scoped, meaning a new instance of ChatDbContext will be created for each HTTP request and shared within that request. The UseNpgsql method configures the context to use PostgreSQL as the database provider, and it retrieves the connection string from the application's configuration settings (e.g., appsettings.json) under the key "DefaultConnection".
//options mean we are passing a lambda expression to configure the DbContext options. In this case, we are specifying that we want to use PostgreSQL as our database provider and providing the connection string from the configuration. This allows our application to connect to the PostgreSQL database when performing data operations through the ChatDbContext.
//npgsql means .net provider for the postgres database 
var app = builder.Build();

//configure middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
} //if the application is running in the development environment, it enables Swagger middleware to generate and serve the API documentation. The UseSwagger method generates the Swagger JSON document, while UseSwaggerUI provides a user-friendly interface to explore and test the API endpoints. This is typically only enabled in development to avoid exposing API documentation in production environments.

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

//health check endpoint
app.MapGet("/health", () => Results.Ok(new { status = "Healthy" }));

app.Run();