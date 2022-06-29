using FlySneakers.Api.Models;
using FlySneakers.Borders.Repositories;
using FlySneakers.Borders.UseCase;
using FlySneakers.Borders.UseCase.Produto;
using FlySneakers.Repositories.Repositories;
using FlySneakers.UseCases;
using FlySneakers.UseCases.Usuario;
using FlySneakers.UseCases.UsuarioDados;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace FlySneakers.Api
{
    public class Startup
    {
        public Microsoft.AspNetCore.Hosting.IHostingEnvironment HostingEnvironment { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            this.HostingEnvironment = env;
            this.Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Fly Sneakers API",
                    Version = "v1",
                    Description = "API responsavel por disponibilizar endPoints que serão utilizados na aplicação de um e-commerce para a venda de calçados e acessorios esportivos. \n\nNa descrição dos endPoints temos informações sobre a execução.",
                    Contact = new OpenApiContact
                    {
                        Name = "Daniel Gustavo Souza Ferreira",
                        Email = "danielgusferreira@hotmail.com",
                    },
                });

                var filePath = Path.Combine(System.AppContext.BaseDirectory, "FlySneakers.Api.xml");
                c.IncludeXmlComments(filePath);
            });

            services.AddScoped<IActionResultConverter, ActionResultConverter>();

            services.AddScoped<IAdicionarItemCarrinhoUseCase, AdicionarItemCarrinhoUseCase>();
            services.AddScoped<IObterCarrinhoUsuarioUseCase, ObterCarrinhoUsuarioUseCase>();
            services.AddScoped<IRemoverItemCarrinhoUseCase, RemoverItemCarrinhoUseCase>();

            services.AddScoped<IObterCategoriaUseCase, ObterCategoriaUseCase>();
            services.AddScoped<ICadastarCategoriaUseCase, CadastarCategoriaUseCase>();
            services.AddScoped<IEditarCategoriaUseCase, EditarCategoriaUseCase>();
            services.AddScoped<IRemoverCategoriaUseCase, RemoverCategoriaUseCase>();

            services.AddScoped<IObterComentarioUseCase, ObterComentarioUseCase>();
            services.AddScoped<ICadastarComentarioUseCase, CadastarComentarioUseCase>();
            services.AddScoped<IEditarComentarioUseCase, EditarComentarioUseCase>();
            services.AddScoped<IRemoverComentarioUseCase, RemoverComentarioUseCase>();

            services.AddScoped<IObterFormaPagamentoUseCase, ObterFormaPagamentoUseCase>();
            services.AddScoped<ICadastarFormaPagamentoUseCase, CadastarFormaPagamentoUseCase>();
            services.AddScoped<IEditarFormaPagamentoUseCase, EditarFormaPagamentoUseCase>();
            services.AddScoped<IRemoverFormaPagamentoUseCase, RemoverFormaPagamentoUseCase>();

            services.AddScoped<IObterMarcaUseCase, ObterMarcaUseCase>();
            services.AddScoped<ICadastarMarcaUseCase, CadastarMarcaUseCase>();
            services.AddScoped<IEditarMarcaUseCase, EditarMarcaUseCase>();
            services.AddScoped<IRemoverMarcaUseCase, RemoverMarcaUseCase>();

            services.AddScoped<ICadastrarPedidoUseCase, CadastrarPedidoUseCase>();
            services.AddScoped<IObterPedidoUseCase, ObterPedidoUseCase>();

            services.AddScoped<IObterProdutoPagInicialUseCase, ObterProdutoPagInicialUseCase>();
            services.AddScoped<IObterProdutoDetalhesUseCase, ObterProdutoDetalhesUseCase>();

            services.AddScoped<ILogarUseCase, LoginUseCase>();
            services.AddScoped<ICadastrarUsuarioUseCase, CadastrarUsuarioUseCase>();
            services.AddScoped<ICadastrarDadosUsuarioUseCase, CadastrarDadosUsuarioUseCase>();
            services.AddScoped<IObterUsuarioDadosUseCase, ObterUsuarioDadosUseCase>();
            services.AddScoped<IVerificarCadastroUsuarioUseCase, VerificarCadastroUsuarioUseCase>();
            services.AddScoped<IObterUsuariosUseCase, ObterUsuariosUseCase>();
            services.AddScoped<IRemoverUsuarioUseCase, RemoverUsuarioUseCase>();

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IUsuarioDadosRepository, UsuarioDadosRepository>();
            services.AddScoped<ICarrinhoRepository, CarrinhoRepository>();
            services.AddScoped<IPedidoRepository, PedidoRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IMarcasRepository, MarcaRepository>();
            services.AddScoped<IComentarioRepository, ComentarioRepository>();
            services.AddScoped<IFormaPagamentoRepository, FormaPagamentoRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fly Sneakers API V1");

                // To serve SwaggerUI at application's root page, set the RoutePrefix property to an empty string.
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
