using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mplace_Web.Areas.Identity.Data;

[assembly: HostingStartup(typeof(Mplace_Web.Areas.Identity.IdentityHostingStartup))]
namespace Mplace_Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Mplace_WebContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Mplace_WebContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<Mplace_WebContext>();
            });
        }
    }
}