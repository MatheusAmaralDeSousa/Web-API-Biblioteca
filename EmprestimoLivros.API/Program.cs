using EmprestimoLivros.API.Context;
using EmprestimoLivros.API.Interface;
using EmprestimoLivros.API.Mappings;
using EmprestimoLivros.API.Modelos;
using EmprestimoLivros.API.Repository;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

/*builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    });
*/
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BibliotecaContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("biblioteca_db"));
});
/*Define para quem é essa interface(Nesse caso para ClienteRepository).
Para que seja possível injetar o context dentro de ClienteRepository.*/
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
/*
 Configura o AutoMapper e define que Map(Classe) vai ser utilizado
*/
builder.Services.AddAutoMapper(typeof(EntitiesToDTOMappingProfile));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
