using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReflectionIT.Mvc.Paging;
using System;

namespace ShopProject
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
            //services.AddDbContext<ShopDbContext>(options =>
            //   options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //Set Session -> 簡単には　services.AddSession()で問題ない
            services.AddSession(option =>
            {
                //Set Session Timeを設定
                option.IdleTimeout = TimeSpan.FromMinutes(20);
            });
            services.AddMvc();
            services.AddPaging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseExceptionHandler("/Home/Error");

            if (env.IsProduction() || env.IsStaging() || env.IsEnvironment("Staging_2"))
                app.UseExceptionHandler("/Error");

            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
