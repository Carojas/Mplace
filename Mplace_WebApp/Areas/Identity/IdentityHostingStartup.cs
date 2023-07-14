using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mplace_WebApp.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Mplace_WebApp.Areas.Identity.IdentityHostingStartup))]
namespace Mplace_WebApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Mplace_WebAppContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Mplace_WebAppContextConnection")));

                services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Mplace_WebAppContext>();
            });
        }
    }
}