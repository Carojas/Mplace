using InyeccionDependencias.Logica;
using InyeccionDependencias.Logica.Interface;
using InyeccionDependencias.Repositorio;
using InyeccionDependencias.Repositorio.Implementa;
using InyeccionDependencias.Repositorio.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InyeccionDependencias.Modelo;
using InyeccionDependencias.Modelo.Interface;
using InyeccionDependencias.Modelo.Implementa;

namespace InyeccionDependencias
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            ConfigurationStartup = configuration;
        }

        public IConfiguration Configuration { get; }
        public static IConfiguration ConfigurationStartup { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "InyeccionDependencias", Version = "v1" });
            });

            //services.AddCors(options => options.AddDefaultPolicy( policy => policy.WithOrigins("*")));
            services.AddCors(options => options.AddPolicy("AccesoUnico", 
                builder => {  builder.WithOrigins("http://localhost:31031")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
                }));

            services.AddEntityFrameworkSqlServer().
                AddDbContext<DataContexto>(option => option.UseSqlServer(Configuration["database:connection"]));

            ////Los objetos con ámbito son los mismos dentro de una solicitud, pero diferentes en diferentes solicitudes.
            services.AddScoped<ILProducto, LProducto>();
            services.AddScoped<IRProducto, RProducto>();
            services.AddScoped<IRFactura, RFactura>();
            services.AddScoped<IRFabrica, RFabrica>();

            ////Los objetos transitorios son siempre diferentes; se proporciona una nueva instancia a cada controlador y cada servicio.
            //services.AddTransient<ILProducto, LProducto>();
            //services.AddTransient<IRProducto, RProducto>();

            ////Los objetos Singleton son los mismos para todos los objetos y todas las solicitudes.
            //services.AddSingleton<ILProducto, LProducto>();
            //services.AddSingleton<IRProducto, RProducto>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "InyeccionDependencias v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AccesoUnico");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
