using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BeFit_Gym.Infraestructure.Data;
using BeFit_Gym.Core.Interfaces;
using BeFit_Gym.Infraestructure.Repository;
using System.Text.Json.Serialization;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BeFit_GymContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BeFit_GymContext") ?? throw new InvalidOperationException("Connection string 'BeFit_GymContext' not found.")));


//CORS
builder.Services.AddCors(options => {
    options.AddPolicy("CorsPolicy", policy => {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    });

// Add services to the container.
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAsistenciaRepository, AsistenciaRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IMembresiaRepository, MembresiaRepository>();
builder.Services.AddScoped<IClienteMembresiaRepository, ClienteMembresiaRepository>();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();

app.UseRouting();


app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
