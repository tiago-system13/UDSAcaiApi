using System.Linq;
using System.Reflection;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using UDSAcaiApi.Dados.Contexto;
using Microsoft.Extensions.Configuration;
using UDSAcaiApi.Dominio.Constantes;
using UDSAcaiApi.Filters;
using UDSAcaiApi.AutoMapper;
using Swashbuckle.AspNetCore.Swagger;
using UDSAcaiApi.Dados.Repositorios;
using UDSAcaiApi.Dominio.Interfaces;
using UDSAcaiApi.Dominio.Servicos.Interfaces;
using UDSAcaiApi.Dominio.Servicos;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using System.Collections.Generic;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Rewrite;

namespace UDSAcaiApi
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private  IHostingEnvironment currentEnvironment { get; set; }
        public Startup(IHostingEnvironment environment, IConfiguration configuration)
        {
            Configuration = configuration;
            currentEnvironment = environment;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc()
              .AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssembly(Assembly.Load("UDSAcaiApi")))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(option => option.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = c =>
                    {
                        var errorMessage = c.ModelState.Values.FirstOrDefault().Errors.FirstOrDefault().ErrorMessage;

                        return new BadRequestObjectResult(new
                        {
                            error = errorMessage
                        });
                    };
                });

            #region Swagger

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new Info { Title = "Acai Service API", Version = "V1" });
            }); 
            #endregion


            #region Conecxão com banco
            string connectionString = EnviromentConstante.DATABASE_CONNECTION_STRING;
            services.AddDbContext<UDSAcaiApiContext>(opt => opt.UseSqlServer(connectionString));
            #endregion

            #region AutoMapper

            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly }); 

            #endregion

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            #region Injeção de Dependência
            services.AddScoped(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
            services.AddScoped<ISaborRepositorio, SaborRepositorio>();
            services.AddScoped<ISaborService, SaborService>();
            services.AddScoped<ITamanhoRepositorio, TamanhoRepositorio>();
            services.AddScoped<ITamanhoService, TamanhoService>();
            services.AddScoped<IPreparacaoRepositorio, PreparacaoRepositorio>();
            services.AddScoped<IPreparacaoService, PreparacaoService>();
            services.AddScoped<IAdicionaisRepositorio, AdicionaisRepositorio>();
            services.AddScoped<IAdicionaisService, AdicionaisService>();
            services.AddScoped<IPedidoRepositorio, PedidoRepositorio>();
            services.AddScoped<IPedidoService, PedidoService>();
            #endregion
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
                app.UseHttpsRedirection();
            }

            var supportedCultures = new[]
           {
                new CultureInfo("pt-BR")
            };

            app.UseRequestLocalization(options =>
            {
                options.DefaultRequestCulture = new RequestCulture("pt-BR");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
                options.RequestCultureProviders = new List<IRequestCultureProvider>
                {
                    new AcceptLanguageHeaderRequestCultureProvider()
                };
            });

            app.UseCors(options => options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowAnyOrigin()
            );

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Açai API V1");
                c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.None);
            });

            //Starting our API in Swagger page
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            //Adding map routing
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "DefaultApi",
                    template: "{controller=Values}/{id?}");
            });


        }
    }
}
