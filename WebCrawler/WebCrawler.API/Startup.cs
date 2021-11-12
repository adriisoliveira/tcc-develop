using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.IO;
using WebCrawler.Business.Interfaces;
using WebCrawler.Business.Interfaces.Repository.Url;
using WebCrawler.Business.Interfaces.Repository.Word;
using WebCrawler.Business.Interfaces.Services;
using WebCrawler.Business.Services;
using WebCrawler.Data.DataContext;
using WebCrawler.Data.Repository.Url;
using WebCrawler.Data.Repository.Word;

namespace WebCrawler.API
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

            #region :: Injeção de Dependência
            services.AddTransient<IScrapperService, ScrapperService>();
            services.AddTransient<ICrawlerService, CrawlerService>();
            services.AddTransient<IPageUrlService, PageUrlService>();
            services.AddTransient<IUrlCrawlerQueueRepository, UrlCrawlerQueueRepository>();

            services.AddTransient<IPageUrlRepository, PageUrlRepository>();
            services.AddTransient<IPageWordRepository, PageWordRepository>();
            services.AddTransient<IUrlCrawlerQueueRepository, UrlCrawlerQueueRepository>();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<WebCrawlerDataContext, WebCrawlerDataContext>();
            
            #endregion

            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.IncludeXmlComments(Path.Combine(System.AppContext.BaseDirectory, "WebCrawler.API.xml"));
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebCrawler.API", Version = "v1" });
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.RoutePrefix = "swagger";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebCrawler.API");
            });
        }
    }
}
