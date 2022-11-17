using CreatorApplication.BLL;
using CreatorApplication.BLL.Contracts;
using CreatorApplication.DAL;
using CreatorApplication.DAL.Contracts;
using CreatorApplication.Data.DataModels;
using CreatorApplication.ViewModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CreatorApplication
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
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IIngredientBLL, IngredientBLL>();
            services.AddScoped<IIngredientDAL, IngredientDAL>();
            //services.AddScoped<IRecipeBLL, RecipeBLL>();
            services.AddScoped<IRecipeDAL, RecipeDAL>();
            services.AddScoped<IBaseBLL<RecipeVm, RecipeUpdateVm, RecipeAddVm>, RecipeBLL>();
            services.AddScoped<IBaseDAL<RecipeVm, RecipeUpdateVm, RecipeAddVm>, RecipeDAL>();
            services.AddScoped<IBaseBLL<IngredientVm, IngredientUpdateVm, IngredientVm>, IngredientBLL>();
            services.AddScoped<IBaseDAL<IngredientVm, IngredientUpdateVm, IngredientVm>, IngredientDAL>();

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
