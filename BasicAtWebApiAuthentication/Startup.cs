using Basic.Auth.Core.Helpers.Implementation;
using Basic.Auth.Core.Helpers.Interface;
using Basic.Auth.Core.Implementations.ProductInterface;
using Basic.Auth.Core.Implementations.UserImplementation;
using Basic.Auth.Core.Interfaces.ProductInterface;
using Basic.Auth.Core.Interfaces.UserInterfaces;
using Basic.Auth.Infrastructure;
using BasicAtWebApiAuthentication.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicAtWebApiAuthentication
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
            services.AddSwaggerGen();
            services.AddControllers();
            services.AddDbContext<BasicAuthDBContext>(options 
                => options.UseSqlServer(Configuration.GetConnectionString("BasicAuth"),
                b => b.MigrationsAssembly(typeof(BasicAuthDBContext).Assembly.FullName)));
            services.AddScoped<IProductServices, ProductService > ();
            services.AddScoped<IUserInterface, UserServices>();
            services.AddScoped<IHelper, Helper>();
            services.AddAuthentication("BasicAuthentication").AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
