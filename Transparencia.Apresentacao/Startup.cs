using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoTransparencia.Infra.Repository.Generic;
using ProjetoTransparencia.Infra.Repository.Permissoes;
using ProjetoTransparencia.Infra.Repository.Requisicoes;
using ProjetoTransparencia.Infra.Repository.TiposDocumento;
using ProjetoTransparencia.Infra.Repository.Usuarios;
using ProjetoTransparencia.Infra.Repositoy.Documentos;
using Transparencia.Application.Apps;
using Transparencia.Application.Interfaces;
using Transparencia.Data.Config;
using Transparencia.Domain.Interfaces.Documentos;
using Transparencia.Domain.Interfaces.Generic;
using Transparencia.Domain.Interfaces.Permissoes;
using Transparencia.Domain.Interfaces.Requisicoes;
using Transparencia.Domain.Interfaces.TiposDocumento;
using Transparencia.Domain.Interfaces.Usuarios;

namespace Transparency
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
			services.AddControllersWithViews();
			services.AddSession();

			services.AddDbContext<ContextBase>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddSingleton(typeof(IInterfaceGeneric<>), typeof(RepositoryGeneric<>));
			services.AddSingleton<IDocumentos,RepositorioDocumentos>();
			services.AddSingleton<IUsuarios, RepositorioUsuarios>();
			services.AddSingleton<IPermissoes, RepositorioPermissoes>();
			services.AddSingleton<IRequisicoes, RepositorioRequisicoes>();
			services.AddSingleton<ITiposDocumento, RepositorioTiposDocumentos>();


			services.AddSingleton<IAppsDocumento, ApplicationDocumento>();
			services.AddSingleton<IAppsUsuario, ApplicationUsuario>();
			services.AddSingleton<IAppsTipoDocumento, ApplicationTipoDocumento>();
			services.AddSingleton<IAppsRequisicao, ApplicationRequisicao>();
			services.AddSingleton<IAppsPermissao, ApplicationPermissao>();


		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}
			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();
			app.UseSession();
			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Login}/{action=Login}/{id?}");
			});
		}
	}
}
