using System.Diagnostics;
using System.Threading.Tasks;
using AspNetCoreProject.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AspNetCoreProject
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddRouting();

            // implement DI here
            //services.AddTransient<Interface, Class>()
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory fact)
        {
            //var routers = new RouteBuilder(app);

            // declare route handlers
            var myRouteHandleHome = new RouteHandler(HandleHome);
            var myRouteHandleGuest = new RouteHandler(HandleHomeGuest);
            // create routers
            var routeBuilderHome = new RouteBuilder(app, myRouteHandleHome);
            var routeBuilderHome1 = new RouteBuilder(app, myRouteHandleGuest);

            routeBuilderHome.MapRoute("default", "Home");
            routeBuilderHome1.MapRoute("default", "Home/Guest");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            #region alternative routing 

            //routers.MapRoute("{controller}", async context =>
            //{
            //    await context.Response.WriteAsync("{controller} template using");
            //});

            //routers.MapRoute("{controller}/{action}", async context =>
            //{
            //    await context.Response.WriteAsync("{controller}/{action} template using");
            //});

            // can use { controller}/{action}/{id?} where {id?} can be empty
            //routers.MapRoute("{controller}/{action}/{id?}", async context =>
            //{
            //    await context.Response.WriteAsync("{controller}/{action}/{id?} template using");
            //});

            // multiple parameters after Id {*catchall} will be route to just {controller}/{action}/{id}
            //routers.MapRoute("{controller}/{action}/{id}/{*catchall}}", async context =>
            //{
            //    await context.Response.WriteAsync("{controller}/{action}/{id}/{*catchall} template using");
            //});
 
            #endregion

            app.UseMiddleware<LoggerMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            // app.UseRouter(routers.Build());
            app.UseRouter(routeBuilderHome.Build());
            app.UseRouter(routeBuilderHome1.Build());
            app.UseMvc(routes =>
            { 
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private async Task HandleHome(HttpContext context)
        {
            await context.Response.WriteAsync("{Home} template using");
        }

        private async Task HandleHomeGuest(HttpContext context)
        {
            await context.Response.WriteAsync("{Home/Guest} template using");
        }
    }
}
