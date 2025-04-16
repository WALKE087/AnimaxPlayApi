using AnimaxPlayApi.Core.Interfaces;
using AnimaxPlayApi.Infrastructure.ExternalServices.Firebase;
using AnimaxPlayApi.Infrastructure.ExternalServices.TMDB;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Dependiencias para funcionamiento de api externa
builder.Services.Configure<TMDBOptions>(builder.Configuration.GetSection("TMDB"));
builder.Services.AddHttpClient<TMDBService>();
builder.Services.AddSingleton<FirebaseAuthService>();

builder.Services.AddControllers();

// Aceptacion de cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwagger();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Pagina principal
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseCors("AllowAnyOrigin");

// Direcctriz se becesuita añadir ls cors para aceptar peticiones
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
