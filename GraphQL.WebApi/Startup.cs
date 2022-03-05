using Food.Graph.Mutation;
using Food.Graph.Query;
using Food.Graph.Schema;
using Food.Graph.Type;
using Food.Interfaces;
using Food.Repository;
using Food.Services;
using GraphiQl;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace GraphQL.WebApi
{
    public class Startup
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _connectionString;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

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
               //.AddSchema<FoodSchema>()
               .AddSystemTextJson()
               .AddValidationRule<Food.InputValidationRule>()                
               //.AddGraphTypes(typeof(FoodSchema).Assembly)
               .AddMetrics(_ => true, (provider, _) => provider.GetRequiredService<IOptions<GraphQLSettings>>().Value.EnableMetrics);

            services.Configure<GraphQLSettings>(Configuration.GetSection("GraphQLSettings"));

            services.AddLogging(builder => builder.AddConsole());
            services.AddHttpContextAccessor();
            services.AddControllers();
            services.AddGraphiQl(x =>
            {
                x.GraphiQlPath = "/graphiql-ui";
                x.GraphQlApiPath = "/graphql";
            });
        
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            var logger = loggerFactory.CreateLogger<Startup>();
            logger.LogInformation($"ConnectionString: {Configuration["ConnectionString"]}");
            if (env.IsDevelopment())
            {
                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
                {
                    serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
                }
            }

            app.UseCors(builder =>
               builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

            app.UseGraphiQl();           

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
