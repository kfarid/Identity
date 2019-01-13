using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace WebApplication1 {
    public class Startup {
        public Startup(IConfiguration configuration) {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddDbContext<IdentityDbContext>(options => {
                options.UseInMemoryDatabase("tempdb");
            });
            services.AddIdentity<IdentityUser, IdentityRole>(options => {
                // options.Password.RequireNonAlphanumeric = false;
                // options.SignIn.RequireConfirmedEmail = true;
                // options.User.RequireUniqueEmail = false;
                // options.Lockout.AllowedForNewUsers = true;
                // options.Lockout.MaxFailedAccessAttempts = 3;
                // options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
            }).AddEntityFrameworkStores<IdentityDbContext>();
                

            // IdentityUser a;
            // IdentityRole b;
            // IdentityDbContext c;
            // UserManager<IdentityUser> d;
            // SignInManager<IdentityUser> e;


            // Models:
            //  User class
            //  UserRole class
            //  UserRole to User connection table
            // Storage:
            //  DbContext
            //    DbSet<User>
            //    DbSet<UserRole>
            //    DbSet<UserRoleUser>
            // Services:
            //  UserService



            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseAuthentication();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
