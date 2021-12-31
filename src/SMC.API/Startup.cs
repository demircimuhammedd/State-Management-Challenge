using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMC.Application.Handlers.CommandHandlers;
using SMC.Core.Repositories;
using SMC.Core.Repositories.Base;
using SMC.Infrastructure.Data;
using SMC.Infrastructure.Repositories;
using SMC.Infrastructure.Repositories.Base;

namespace SMC.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<SMCContext>(m => m.UseSqlServer(Configuration.GetConnectionString("SMCDB"),c=>c.MigrationsAssembly("SMC.API")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "SMC.API", Version = "v1" }); });

            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateTaskHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ITaskRepository, TaskRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SMC.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}