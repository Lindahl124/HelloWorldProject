var builder = WebApplication.CreateBuilder(args);

// Lägg till tjänster för controllers
builder.Services.AddControllers();  

// Lägg till CORS-tjänst och definiera en policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend", policy =>
    {
        // Tillåt anrop från localhost:3002 (din frontend)
        policy.WithOrigins("http://localhost:3002")  
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Aktivera CORS-policyn
app.UseCors("AllowFrontend");  

// Lägg till routing för dina controllers
app.MapControllers();  // Detta gör att HelloWorldController kan användas

app.UseHttpsRedirection();  // Om du inte använder HTTPS kan du ta bort detta

app.Run();
