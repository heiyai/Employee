using Employee.Interface;
using Employee.Model;
using Employee.Service;
using EmployeeWebAPI.Utility.Filter;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace EmployeeWebAPI
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
            services.AddControllers();
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<InterviewContext>(options =>
                {
                    options.UseSqlServer(Configuration.GetConnectionString("DBConnection"));
                });
            services.AddScoped<DbContext, InterviewContext>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<ITaskService, TaskService>();
            services.AddSingleton<CustomExceptionFilterAttribute>();
            services.AddCors(option => option.AddPolicy("AllowCors", _build => _build.AllowAnyOrigin().AllowAnyMethod()));
            services.AddMvc(option =>
            {
                option.Filters.Add(typeof(CustomExceptionFilterAttribute));
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors("AllowCors");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
