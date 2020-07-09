using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tro.DbGrade.Server.DataAcesses;
using Tro.DbGrade.Server.Storage;
using Tro.FrameWork.Extensions.Rename;

namespace Tro.DbGrade.Server
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddOptions<RenameDbOptions>()
                .Bind(Configuration.GetSection(RenameDbOptions.RenameDb));
            services.AddRenameDbService<RenameDbService>();
            services.AddDbContext<GradeDbContext>();
            services.AddDataAccessService(options =>
            {
                options.EachCount = 10;

            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoint => {
                endpoint.MapDefaultControllerRoute();

            });
        }
    }
}
