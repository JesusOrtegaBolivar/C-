using AccesoDatosCore.Data;
using AccesoDatosCore.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccesoDatosCore
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
            Bici bicicleta = new Bici();
            bicicleta.Marca = "Marca de bici";
            bicicleta.Modelo = "Modelo de bici";
            bicicleta.Velocidad = 0;
            bicicleta.VelocidadMaxima = 50;
            services.AddTransient<Bici>(bici => bicicleta);

            String cadenaconexion = this.Configuration.GetConnectionString("hospitallocal");
            HospitalesContext hospitalcontext = new HospitalesContext(cadenaconexion);
            EnfermoContext enfermoContext = new EnfermoContext(cadenaconexion);
            PlantillasContext conxtext = new PlantillasContext(cadenaconexion);
            EmpleadosContext context = new EmpleadosContext(cadenaconexion);
            services.AddTransient<EmpleadosContext>(contexto => context);
            services.AddTransient<PlantillasContext>(contexto => conxtext);
            services.AddTransient<EnfermoContext>(contexto => enfermoContext);
            services.AddTransient<HospitalesContext>(contexto => hospitalcontext);


            services.AddControllersWithViews();
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
