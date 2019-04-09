using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Rental.BL;

namespace EquipmentRental.Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Configuration = configuration;
            _environment = env;
        }

        private IHostingEnvironment _environment;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddTransient<AbstractEquipmentFactory, EquipmentFactory>();
            //services.AddScoped<IEquipmentRepository, FileBasedEquipmentRepository>();
            


            services
                .AddScoped<IEquipmentRepository>(
                    provider =>
                        new FileBasedEquipmentRepository(
                                provider.GetService<ILogger<FileBasedEquipmentRepository>>(),
                                provider.GetService<AbstractEquipmentFactory>(),
                                Path.Combine(ApplicationEnvironment.ApplicationBasePath, "equipment_repository.txt")
                                ));

            services.AddTransient<IEquipmentInventory, EquipmentInventory>();



            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
