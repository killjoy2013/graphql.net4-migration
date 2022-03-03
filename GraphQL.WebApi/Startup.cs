using GraphQL;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using GraphQL.WebApi.Graph.Mutation;
using GraphQL.WebApi.Graph.Query;
using GraphQL.WebApi.Graph.Schema;
using GraphQL.WebApi.Graph.Type;
using GraphQL.WebApi.Interfaces;
using GraphQL.WebApi.Repository;
using GraphQL.WebApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace GraphQL.WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _connectionString;
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            _connectionString = Configuration["ConnectionString"];
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseNpgsql(_connectionString);
            });
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IFieldService, FieldService>();
            services.AddScoped<MainMutation>();
            services.AddScoped<MainQuery>();
            services.AddScoped<RestaurantGType>();
            services.AddScoped<TagGType>();
            services.AddScoped<ISchema, FoodSchema>();
            services.AddGraphQL()                
              .AddGraphTypes(ServiceLifetime.Scoped);

            services.AddCors();
            
            services.Configure<KestrelServerOptions>(options =>
            {
                options.AllowSynchronousIO = true;
            });

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                       options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {     
            app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
           
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions());
          
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
