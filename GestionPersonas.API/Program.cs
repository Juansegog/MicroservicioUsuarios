using AutoMapper;
using FluentValidation;
using FluentValidation.AspNetCore;
using GestionPersonas.API;
using GestionPersonas.Application.CaracteristicasPaciente.Comandos;
using GestionPersonas.Application.Map;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);
var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton<GenericMapperService>();
// Agregar servicios adicionales despu�s de configurar los servicios principales.

builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<CrearComandoPacienteValidacion>();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
