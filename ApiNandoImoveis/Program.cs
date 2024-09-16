using ApiNandoImoveis.Context;
using ApiNandoImoveis.Repositories;
using ApiNandoImoveis.Repositories.Interfaces;
using ApiNandoImoveis.Services;
using ApiNandoImoveis.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(x =>
             x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var MySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(MySqlConnection, ServerVersion.AutoDetect(MySqlConnection)));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ICliente, ClienteRepository>();
builder.Services.AddScoped<IImoveis, ImovelRepository>();
builder.Services.AddScoped<IFuncionario, FuncionarioRepository>();
builder.Services.AddScoped<IClienteServices, ClientesServices>();
builder.Services.AddScoped<IImoveisServices, ImovelServices>();
builder.Services.AddScoped<IFuncionarioServices, FuncionarioServices>();

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
