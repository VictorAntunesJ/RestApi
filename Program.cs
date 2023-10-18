using System.Reflection;
using MaisEventosVsCode.Context;

using MaisEventosVsCode.Interfaces;
using MaisEventosVsCode.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<MaisEventosVsCodeContextApi>(
    options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("ConexaoPadrao")
        ));

builder.Services.AddScoped<IUsuarioRepository, UsuarioTestRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MaisEventos.Api",
        Version = "v1",
        Description = "Api desenvolvida para site PipocaAgil.Api",
        TermsOfService = new  Uri("https://meusite.com"),
        Contact = new OpenApiContact
        {
            Name = "Victor Sérgio",
            Url = new Uri("https://meusite.com")
        },
        License = new OpenApiLicense
        {
            Name = "PipocaAgil.Api",
            Url = new Uri("https://meusite.com")
        }

    });

    //Add Configuracoes extras da documentaçao, para ler os XMLs
    var xmlArquivo = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlArquivo));
});

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
