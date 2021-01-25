using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Bussiness.Extensions.DIResolvers;
using ToDoList.Bussiness.Extensions.IdentityConfigurations;
using ToDoList.Bussiness.Extensions.ValidationConfig;
using ToDoList.DataAccess.Concrete.EntityFramework.Context;
using ToDoList.Entities.Concrete;
using ToDoList.WEB.Functions;

namespace ToDoList.WEB
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddFluentValidation();
            //CODEvils Data Transfer Object
            services.AddDbContext<MyDataContext>();
            services.AddContainerWithDependencies(); //DI isleri bundan sorulur
            services.AddIdentityConfiguration();
            services.CookieConfigurations("/Home/Login");
            services.ValidatorConfig();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            IdentityInitilaizer.SeedData(userManager, roleManager).Wait();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Events}/{action=Index}/{id?}"
                    );
            });
        }
    }
}
