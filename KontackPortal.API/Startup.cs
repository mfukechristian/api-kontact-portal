using KontackPortal.Repository;
using Microsoft.OpenApi.Models;
using KontackPortal.DomainLogic;

namespace KontackPortal.API
{
    public class Startup
    {
        private readonly string _dbConnectionString;
        private string _contentUrl;
        private string _runtimeEnv;
        private string _version;

        public Startup(IConfiguration configuration)
        {
            _dbConnectionString = configuration.GetConnectionString("WebApiDatabase");      
            SetupEnvironmentVariables();
        }

        private void SetupEnvironmentVariables()
        {

            _runtimeEnv ="WebApiDatabase";
            _version =  "WebApiDatabase";
        }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddControllers();
            services.AddRepository(_dbConnectionString);
            SetupServices(services);
            SetupRepositories(services);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Contact - Portal API", Version = "v1" });
            });
        }

        private void SetupServices(IServiceCollection services)
        {
            services.AddEnvironmentService(_runtimeEnv);
            services.AddDomainLogicServices();
        }

        private static void SetupRepositories(IServiceCollection repositories) => repositories.AddRepositories();

        public void Configure(IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Contact - Portal API v1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
