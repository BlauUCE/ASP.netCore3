using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Prueba.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Text;
using Microsoft.AspNetCore.Http;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace Prueba
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();

                //mesaje excepcion personalizado
                //app.UseExceptionHandler(options =>
                //{
                //    options.Run(async context =>
                //    {
                //        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                //        context.Response.ContentType = "text/html";
                //        var ex = context.Features.Get<IExceptionHandlerFeature>();
                //        if (ex != null)
                //        {
                //            var error = $"<h1>Error {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                //            await context.Response.WriteAsync(error).ConfigureAwait(false);
                //        }
                //    });
                //});

                //app.UseExceptionHandler("/Home/Error");

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //obtener codigos de errores de la aplicacion
            //muestra una vista con Status Code: 404; Not Found  
            //app.UseStatusCodePages();

            //personalizar mensajes
            //no funciona tildes
            //String str = "P�gina de c�digo de estado, c�digo {0}";
            //byte[] bytes = Encoding.Default.GetBytes(str);
            //str = Encoding.UTF8.GetString(bytes);
            //str = System.Web.HttpUtility.HtmlDecode("P�gina de c�digo de estado, c�digo {0}");
            //app.UseStatusCodePages("text/plain", str);

            //app.UseStatusCodePages("text/plain", "Pagina de codigo de estado, codigo {0}");

            //personalizar el mensaje
            //app.UseStatusCodePages( async context =>
            //{
            //    await context.HttpContext.Response.WriteAsync(
            //        "Pagina de codigo de estado, codigo " +
            //        context.HttpContext.Response.StatusCode
            //        );
            //});

            //otra forma con tildes
            //app.UseStatusCodePagesWithRedirects("/Usuarios/Metodo?code={0}");

            //otra forma con tildes
            //app.UseStatusCodePagesWithReExecute("/Usuarios/Metodo", "?code={0}");

            //con la vista error
            app.UseStatusCodePagesWithReExecute("/Home/Error", "?statusCode={0}");


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
