using Microsoft.AspNetCore.Authentication.JwtBearer;
using InDoorMappingAPI.Data;
using InDoorMappingAPI.Repos;
using InDoorMappingAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using InDoorMappingAPI.Repos.Interfaces;
using InDoorMappingAPI.Services.Interfaces;

namespace InDoorMappingAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add Connection

            builder.Services.AddDbContext<DataContext>(options =>
                options.UseNpgsql("Server=tassi-t1-5318.jxf.gcp-europe-west1.cockroachlabs.cloud;Port=26257;Userid=1240605;Password=v2zNb2wsnA9NxRPWEsf4pw;Pooling=false;MinPoolSize=1;MaxPoolSize=20;Timeout=15;SSL Mode=Require"));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Adding Repos
            builder.Services.AddScoped<IUsuarioRepo, UsuarioRepo>();
            builder.Services.AddScoped<IAcessibilidadeRepo, AcessibilidadeRepo>();
            builder.Services.AddScoped<IBeaconRepo, BeaconRepo>();
            builder.Services.AddScoped<ILogRepo, LogRepo>();
            builder.Services.AddScoped<IMobilidadeRepo, MobilidadeRepo>();
            builder.Services.AddScoped<ICaminhoRepo, CaminhoRepo>();
            builder.Services.AddScoped<IInfraestruturaRepo, InfraestruturaRepo>();
            builder.Services.AddScoped<IComandoEpocRepo, ComandoEpocRepo>();
            builder.Services.AddScoped<IDiarioRepo, DiarioRepo>();
            builder.Services.AddScoped<IFeedbackCaminhoRepo, FeedbackCaminhoRepo>();

            // Adding Services
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IAcessibilidadeService, AcessibilidadeService>();
            builder.Services.AddScoped<IBeaconService, BeaconService>();
            builder.Services.AddScoped<ILogService, LogService>();
            builder.Services.AddScoped<IMobilidadeService, MobilidadeService>();
            builder.Services.AddScoped<ICaminhoService, CaminhoService>();
            builder.Services.AddScoped<IInfraestruturaService, InfraestruturaService>();
            builder.Services.AddScoped<IComandoEpocService, ComandoEpocService>();
            builder.Services.AddScoped<IDiarioService, DiarioService>();
            builder.Services.AddScoped<IFeedbackCaminhoService, FeedbackCaminhoService>();

            // Adding AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // JWT Configuration
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var key = builder.Configuration["Jwt:Key"];
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
        };
    });
            builder.WebHost.UseUrls("http://0.0.0.0:8080");

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseSwagger();
            app.UseSwaggerUI();


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
