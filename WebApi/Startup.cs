using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.XPath;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Dal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.PlatformAbstractions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Service;
using Swashbuckle;
using Swashbuckle.AspNetCore.Swagger;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            if (services.BuildServiceProvider().GetService<IHostingEnvironment>().IsDevelopment())
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info
                    {
                        Title = "api",
                        Version = "v1"
                    });
                    foreach (var path in GetXmlCommentsPaths())
                    {
                        c.IncludeXmlComments(path);
                    }
                });
            }
            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterType<ControllerBase>().AsSelf();
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly).AsSelf().AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(UserDa).Assembly).AsSelf().AsImplementedInterfaces();
            var container = builder.Build();
            return new AutofacServiceProvider(container);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "api");
                });
            }

            app.UseMvc();
        }

        private static string[] GetXmlCommentsPaths()
        {
            var searchFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            return Directory.EnumerateFiles(searchFolder, "*.xml", SearchOption.AllDirectories).ToArray();
        }
    }
}
