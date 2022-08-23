using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using WoMakersCode.Biblioteca.Application.Mappings;
using WoMakersCode.Biblioteca.Application.Models.AdicionarAutor;
using WoMakersCode.Biblioteca.Application.Models.AdicionarLivro;
using WoMakersCode.Biblioteca.Application.Models.AdicionarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Autor.AtualizarAutor;
using WoMakersCode.Biblioteca.Application.Models.Autor.DeletarAutor;
using WoMakersCode.Biblioteca.Application.Models.DeletarAutor;
using WoMakersCode.Biblioteca.Application.Models.DeletarLivro;
using WoMakersCode.Biblioteca.Application.Models.DeletarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AdicionarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.AtualizarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.DeletarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Emprestimo.ListarEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.ListarAutor;
using WoMakersCode.Biblioteca.Application.Models.ListarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.AdicionarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.AtualizarLivro;
using WoMakersCode.Biblioteca.Application.Models.Livro.DeletarLivro;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.DevolucoesEmAtraso;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosDisponiveis;
using WoMakersCode.Biblioteca.Application.Models.Relatorio.LivrosEmEmprestimo;
using WoMakersCode.Biblioteca.Application.Models.Usuario.AtualizarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.DeletarUsuario;
using WoMakersCode.Biblioteca.Application.Models.Usuario.ListarUsuario;
using WoMakersCode.Biblioteca.Application.UseCases;
using WoMakersCode.Biblioteca.Application.UseCases.AutorUseCase;
using WoMakersCode.Biblioteca.Application.UseCases.EmprestimoUseCase;
using WoMakersCode.Biblioteca.Application.UseCases.LivroUseCase;
using WoMakersCode.Biblioteca.Application.UseCases.RelatorioUseCase;
using WoMakersCode.Biblioteca.Application.UseCases.UsuarioUseCase;
using WoMakersCode.Biblioteca.Core.Repositories;
using WoMakersCode.Biblioteca.Infra.DataBase;
using WoMakersCode.Biblioteca.Infra.Respositories;

namespace WoMakersCode.Biblioteca.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAutorRepository, AutorRepository>();
            services.AddTransient<IEmprestimoRepository, EmprestimoRepository>();
            services.AddTransient<ILivroRepository, LivroRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IRelatorioRepository, RelatorioRepository>();
            services.AddTransient<IUseCaseAsync<int, ListarAutorResponse>, ListarAutorIdUseCase>();
            services.AddTransient<IUseCaseAsync<ListarAutorRequest, List<ListarAutorResponse>>, ListarAutorUseCase>();
            services.AddTransient<IUseCaseAsync<AdicionarAutorRequest, AdicionarAutorResponse>, AdicionarAutorUseCase>();
            services.AddTransient<IUseCaseAsync < AtualizarAutorRequest, AtualizarAutorResponse >, AtualizarAutorUseCase >();
            services.AddTransient<IUseCaseAsync<DeletarAutorIdRequest, DeletarAutorIdResponse>, DeletarAutorIdUseCase>();
            services.AddTransient<IUseCaseAsync<int, ListarLivroResponse>, ListarLivroIdUseCase>();
            services.AddTransient<IUseCaseAsync<ListarLivroRequest, List<ListarLivroResponse>>, ListarLivroUseCase>();
            services.AddTransient<IUseCaseAsync<AdicionarLivroRequest, AdicionarLivroResponse>, AdicionarLivroUseCase>();
            services.AddTransient<IUseCaseAsync<AtualizarLivroRequest, AtualizarLivroResponse >, AtualizarLivroUseCase>();
            services.AddTransient<IUseCaseAsync<DeletarLivroIdRequest, DeletarLivroIdResponse>, DeletarLivroIdUseCase>();
            services.AddTransient<IUseCaseAsync<int, ListarUsuarioResponse>, ListarUsuarioIdUseCase>();
            services.AddTransient<IUseCaseAsync<ListarUsuarioRequest, List<ListarUsuarioResponse>>, ListarUsuarioUseCase>();
            services.AddTransient<IUseCaseAsync<AdicionarUsuarioRequest, AdicionarUsuarioResponse>, AdicionarUsuarioUseCase >();       
            services.AddTransient<IUseCaseAsync<AtualizarUsuarioRequest, AtualizarUsuarioResponse>, AtualizarUsuarioUseCase >();       
            services.AddTransient<IUseCaseAsync<DeletarUsuarioIdRequest, DeletarUsuarioIdResponse>, DeletarUsuarioIdUseCase>();
            services.AddTransient<IUseCaseAsync<int, ListarEmprestimoResponse>, ListarEmprestimoIdUseCase>();
            services.AddTransient<IUseCaseAsync<ListarEmprestimoRequest, List<ListarEmprestimoResponse>>, ListarEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<AdicionarEmprestimoRequest, AdicionarEmprestimoResponse>, AdicionarEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<AtualizarEmprestimoRequest, AtualizarEmprestimoResponse>, AtualizarEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<DeletarEmprestimoIdRequest, DeletarEmprestimoIdResponse>, DeletarEmprestimoIdUseCase>();
            services.AddTransient<IUseCaseAsync<DevolucoesEmAtrasoFiltroRequest, List<DevolucoesEmAtrasoResponse>>, RelatorioDevolucoesEmAtrasoUseCase>();
            services.AddTransient<IUseCaseAsync<LivrosEmEmprestimoRequest, List<LivrosEmEmprestimoResponse>>, RelatorioLivrosEmEmprestimoUseCase>();
            services.AddTransient<IUseCaseAsync<LivrosDisponiveisRequest, List<LivrosDisponiveisResponse>>, RelatorioLivrosDisponiveisUseCase>();

            services.AddAutoMapper(typeof(MappingProfile));

            services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"))
                .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
             );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WoMakersCode.Biblioteca.API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WoMakersCode.Biblioteca.API v1"));
            }

            context.Database.Migrate();

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
