using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Teste_MongoBD2.Data;
using API_Teste_MongoDB.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API_Teste_MongoDB1
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {

            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: false)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            //Para acessar os dados das coleções
            services.AddTransient<GradeContext>();
            services.AddTransient<UsersContext>();
            services.AddTransient<UserLogContext>();
            services.AddTransient<UserProgressContext>();
            services.AddTransient<UserDetailContext>();
            services.AddTransient<UserMatchContext>();
            services.AddTransient<UserMatchDetailsContext>();

            //Adiciona o serviço MVC na configuração da api
            services.AddMvc();

            //Adicionar o compressor de requisições
            services.AddResponseCompression();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Adiciona o serviço MVC na aplicação
            app.UseMvc();

            //Adicionar para completar o use (service)
            app.UseResponseCompression();

           

        }
    }
}
