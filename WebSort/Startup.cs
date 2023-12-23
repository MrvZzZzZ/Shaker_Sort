using Microsoft.AspNetCore.Mvc;
using Dapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace WebSort
{
    public class Startup
    {
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		[Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = "Data Source=DESKTOP-FOCMMOT\\SQLSERVER;Initial Catalog=Arrays;Persist Security Info=True;User ID=sa;Password=sa;Encrypt=False";
            services.AddTransient<IArrayRepository, ArrayRepository>(provider => new ArrayRepository((connectionString)));
			services.AddScoped<IArrayRepository, ArrayRepository>();
			//services.AddControllersWithViews();
			services.AddControllersWithViews()
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller=HomeController}/{action=Index}/{id?}");
            });
        }
    }
}
