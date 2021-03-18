using DgpaysProject.Core.Repository.Interface.Acquiring;
using DgpaysProject.Core.Repository.Interface.Issuing;
using DgpaysProject.Core.Repository.Interface.Transaction;
using DgpaysProject.Core.Repository.Repository.Acquiring;
using DgpaysProject.Core.Repository.Repository.Issuing;
using DgpaysProject.Core.Repository.Repository.Transaction;
using DgpaysProjectBusiness.Concrete;
using DgpaysProjectBusiness.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DgpaysProjectUI
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
            services.AddScoped<ICustomerBusiness, CustomerBusiness>();
            services.AddScoped<ITransactionBusiness, TransactionBusiness>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ITransactionMasterRepository, TransactionMasterRepository>();
            services.AddScoped<ICardRepository, CardRepository>();
            services.AddScoped<ITerminalMasterRepository, TerminalMasterRepository>();
            services.AddScoped<IMerchantMasterRepository, MerchantMasterRepository>();


            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(LogExampleAttribute));
            //});

            services.AddSwaggerDocument(config=> {
                config.PostProcess = (doc =>
                {
                doc.Info.Title = "Documentation";
                doc.Info.Description = "Services for backend";
                doc.Info.Version = "1.0.0";
                    doc.Info.Contact = new NSwag.OpenApiContact()
                    {
                        Email = "muzaffer.akgul@dgpaysit.com",
                        Name = "Muzaffer Akgül",
                        Url="www.dgpays.com"
                    };
                });
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

            app.UseOpenApi();
            app.UseSwaggerUi3();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
