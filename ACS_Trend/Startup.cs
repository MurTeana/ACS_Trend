using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using ACS_Trend.Domain.Interfaces;
using ACS_Trend.DataAccess.EFCore;
using ACS_Trend.DataAccess.EFCore.Repositories;
using ACS_Trend.DataAccess.EFCore.UnitOfWorks;

namespace ACS_Trend
{
    public class Startup
    {
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {           
            //services.AddControllersWithViews();           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(Configuration["ConnectionStrings:DefaultConnection"]));

            //Add repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddTransient<IControl_objectRepository, Control_objectRepository>();
            //services.AddTransient<IControl_object_typeRepository, Control_object_typeRepository>();
            //services.AddTransient<IRegulatorRepository, RegulatorRepository>();
            //services.AddTransient<ISignal_typeRepository, Signal_typeRepository>();
            //services.AddTransient<IStationRepository, StationRepository>();
            //services.AddTransient<IStation_typeRepository, Station_typeRepository>();
            //services.AddTransient<ITransient_characteristicRepository, Transient_characteristicRepository>();
            //services.AddTransient<ITrendRepository, TrendRepository>();
            //services.AddTransient<ITrend_parameterRepository, Trend_parameterRepository>();
            //services.AddTransient<ITrend_parameter_typeRepository, Trend_parameter_typeRepository>();
            //services.AddTransient<ITrendPointRepository, TrendPointRepository>();
            services.AddTransient<IUnitRepository, UnitRepository>();

            //Add UnitOfWork
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            //Add Controllers
            services.AddControllers();
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
