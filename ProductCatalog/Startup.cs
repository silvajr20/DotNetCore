using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductCatalog.Data;
using ProductCatalog.Models;
using ProductCatalog.Repositorios;
using Swashbuckle.AspNetCore.Swagger;


namespace ProductCatalog
{
    public class Startup
    {

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adiciona o serviço MVC na configuração da api
            services.AddMvc();

            //Adicionar o compressor de requisições
            services.AddResponseCompression();
                  
            // poderia ser AddScoped
            services.AddScoped<StoreDataContext, StoreDataContext>();

            //Adicionar serviço do repositório do produto
            services.AddTransient<ProdutoRepositorio, ProdutoRepositorio>();

            services.AddSwaggerGen(x=>{
                x.SwaggerDoc("v1", new Info{ Title = "Aplicação Crud" , Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //****** COMENTAR O CÓDIGO ABAIXO PARA        *****************************
            //      A API GERAR UM ARRAY VAZIO PARA A CRIÇÃO DOS JSONs
            //*************************************************************************
            
            /*app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Ola mundo!");
            });*/
            
            //Adiciona o serviço MVC na aplicação
            app.UseMvc();

            //Adicionar para completar o use (service)
            app.UseResponseCompression();

            //Adicionar para completar o use (service)
            app.UseSwagger();

            //Adicionar para poder utilizar a interface gráfica do swagger
            app.UseSwaggerUI(x => {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "Aplicacao - V1");
            });


        }
    }
}
