using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ControleFolhaPagamento.API.Configuration;
using ControleFolhaPagamento.Aplicacao.Infraestrutura.Contexts;
using ControleFolhaPagamento.API.Middlewares;

namespace ControleFolhaPagamento.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegistrarDependencias();
            services.AddControllers();

            services.AddDbContext<GlobalContext>(options =>
            {           
                options.UseNpgsql(Configuration.GetConnectionString("Default"));
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMiddleware<TratadorExcecoes>();
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
