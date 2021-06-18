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
using ProgrammingProject.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Globalization;

namespace ProgrammingProject
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
            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddAuthentication()
                .AddJwtBearer(o => {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = true;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidAudience = Configuration["Jwt:Audience"],
                        ValidIssuer = Configuration["Jwt:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                    };
                });
            services.AddControllersWithViews();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            var cultureInfo = new CultureInfo("en-AU");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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

            app.UseCors(o =>
            {
                o.AllowAnyMethod();
                o.AllowAnyOrigin();
                o.AllowAnyHeader();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });

            CreateUserRoles(services).Wait();
            InsertBaseData(services).Wait();
            MakeSystemAdmin(services).Wait();
        }

        private async Task CreateUserRoles(IServiceProvider sp)
        {
            var rm = sp.GetRequiredService<RoleManager<IdentityRole>>();
            string[] roles = { "Staff", "Manager", "Member" };
            foreach (var r in roles)
            {
                bool exists = await rm.RoleExistsAsync(r);
                if (!exists)
                {
                    var role = new IdentityRole(r);
                    await rm.CreateAsync(role);
                }
            }
        }
        private async Task InsertBaseData(IServiceProvider sp)
        {
            var context = sp.GetRequiredService<ApplicationDbContext>();
            var restaurants = await context.Restaurants.ToListAsync();
            if (restaurants.Count <= 0)
            {
                await context.Database.ExecuteSqlRawAsync("SetInitialData 'Crocodile Dilemma'");
            }
        }

        private async Task MakeSystemAdmin(IServiceProvider sp)
        {
            var context = sp.GetRequiredService<ApplicationDbContext>();
            var person = context.People
                         .Where(x => x.Email == "manager@test.com").FirstOrDefault();
            if (person == null)
            {
                var userManager = sp.GetRequiredService<UserManager<ApplicationUser>>();
                person = new Person()
                {
                    Email = "manager@test.com",
                    FirstName = "Manager",
                    Surname = "Test",
                    Phone = "0411111111",
                };
                context.People.Add(person);
                var user = new ApplicationUser()
                {
                    UserName = "manager@test.com",
                    Email = "manager@test.com",
                    EmailConfirmed = true,
                    IsDeleted = false
                };
                var userResult = userManager.CreateAsync(user, "P@ssw0rd").Result;
                var admin = userManager.FindByEmailAsync("manager@test.com").Result;
                await userManager.AddToRolesAsync(admin, new string[] { "Manager", "Staff" });
                await context.SaveChangesAsync();
            }
        }
    }
}
