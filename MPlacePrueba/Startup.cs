using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPlacePrueba
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<Startup> logger)
        {
            #region Delegado Original

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            #endregion Delegado Original

            #region use y run

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Use(async (context, next) => { 
            //    await context.Response.WriteAsync("Camino Principal");
            //    //await next.Invoke();
            //});

            //app.Run(async context =>
            //{
            //    //logger.LogInformation("Prueba Log");
            //    await context.Response.WriteAsync("Camino2");
            //});

            #endregion use y run

            #region Map

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Map("/mapeo1", RespuestaMapeo1);
            //app.Map("/mapeo2", RespuestaMapeo2);

            #endregion Map

            #region use static

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //DefaultFilesOptions d = new DefaultFilesOptions();
            //d.DefaultFileNames.Clear();
            //d.DefaultFileNames.Add("NoDefecto.html");

            //app.UseDefaultFiles(d);
            //app.UseStaticFiles();


            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync("No ingreso al no default");
            //});

            #endregion use static

            #region Ejercicio

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Map("/map1", MostrarImg);
            //app.Map("/map2", MostrarTexto);

            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("Este es el paso USE");
            //    await next.Invoke();
            //});

            //app.Run(async context =>
            //{
            //    await context.Response.WriteAsync(" Y Este es el paso RUN");
            //});

            #endregion Ejercicio
        }

        #region Funciones Map

        static void RespuestaMapeo1(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Mapeo 1");
            });
        }

        static void RespuestaMapeo2(IApplicationBuilder app)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync("Mapeo 2");
            });
        }

        #endregion Funciones Map

        #region Funciones Ejercicio

        static void MostrarImg(IApplicationBuilder app)
        {
            AsignarArchivoPorDefecto(app, "LuffyP.jpg");
        }

        static void MostrarTexto(IApplicationBuilder app)
        {
            AsignarArchivoPorDefecto(app, "PaginaTexto.html");
        }

        static void AsignarArchivoPorDefecto(IApplicationBuilder app, string file)
        {
            DefaultFilesOptions d = new DefaultFilesOptions();
            d.DefaultFileNames.Clear();
            d.DefaultFileNames.Add(file);

            app.UseDefaultFiles(d);
            app.UseStaticFiles();

            app.Run(async context =>
            {
                await context.Response.WriteAsync("Fallo al cargar");
            });

        }

        #endregion Funciones Ejercicio


    }
}
