
using FilasEGuichesApi.Data;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using FilasEGuichesApi.Data.Repository;
using FilasEGuichesApi.Models;
using FilasEGuichesApi.Services;

namespace FilasEGuichesApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Criando um construtor de aplicação web (api)
            var builder = WebApplication.CreateBuilder(args);

            // Montando a aplicação web (api)
            #region Configuracao da Base de Dados

            builder.Services.AddDbContext<AppDbContext>(option => option.UseInMemoryDatabase("BaseFilasEGuichesApi"));

            #endregion

            #region Configuracao dos Cors

            // Habilitar recebimento de conexões/requisições da mesma rede
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            #endregion

            #region Configuracao da Cultura da Aplicação

            // Português do Brasil
            var cultureInfo = new CultureInfo("pt-BR");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            #endregion

            #region Adicionar Serviços ao Escopo

            // Scoped
            builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>)); // Registro do repositório genérico
            builder.Services.AddScoped<IGuicheService, GuicheService>();
            builder.Services.AddScoped<ITipoGuicheService, TipoGuicheService>();
            builder.Services.AddScoped<IFichaService, FichaService>();
            // Singleton

            // Transient

            #endregion

            builder.Services.AddControllers();

            #region Configuracao da Documentacao da API com Swagger

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #endregion

            // Construindo a aplicacao
            var app = builder.Build();

            // Habilitando recursos da aplicação
            #region Abrir Documentacao da API no Swagger

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            #endregion

            #region Mocks

#if DEBUG
            var scope = app.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            dbContext.SeedData();
#endif

            #endregion


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            // Iniciar a aplicação
            app.Run();
        }
    }
}
