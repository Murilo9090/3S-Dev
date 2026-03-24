using Azure.AI.ContentSafety;
using EventPlus.WebAPI;
using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

var endpoint = "";
var apiKey = "";

var client = new ContentSafetyClient(new Uri(endpoint), new Azure.AzureKeyCredential(apiKey));

builder.Services.AddSingleton(client);

builder.Services.AddDbContext<EventContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Registrar as repositories (Injeção de Dependencia) 
builder.Services.AddScoped<IPresencaRepository, PresencaRepository>();
builder.Services.AddScoped<ITipoUsuarioRepository, TipoUsuarioRepository>();
builder.Services.AddScoped<ITipoEventoRepository,TipoEventoRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IEventoRepository, EventoRepository>();
builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
builder.Services.AddScoped<IComentarioEventoRepository, ComentarioEventoRepository>();
//Adiciona Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>

{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.OpenApiInfo
    {
        Version = "v1",
        Title = "API de Eventos",
        Description = "Aplicação para gerenciamento de eventos",
        TermsOfService = new Uri("https://exemple.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Murilo9090",
            Url = new Uri("https://github.com/Murilo9090")
        },
        License = new OpenApiLicense
        {
            Name = "Exemple Licence",
            Url = new Uri("https://exemple.com/license")
        }
    });
//Usando a autenticação no swagger
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = "Insira o token JWT: "
});
    options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
    {
        [new OpenApiSecuritySchemeReference("Bearer", document)] = Array.Empty<string>().ToList(),
    });
    
    
});
        var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwagger(options => { });
    app.UseSwaggerUI(options =>
    {   
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Eventos v1");
        options.RoutePrefix = string.Empty;
    });
}
app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
