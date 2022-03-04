using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.SystemTextJson;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Food;
using Food.Graph.Schema;
using Food.Repository;
using Microsoft.EntityFrameworkCore;
using Food.Interfaces;
using Food.Services;
using Food.Graph.Mutation;
using Food.Graph.Query;
using Food.Graph.Type;
using GraphiQl;

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
            //services.AddScoped<FoodSchema>();
            //services.AddScoped<IDataLoaderContextAccessor, DataLoaderContextAccessor>();
            //services.AddScoped<DataLoaderDocumentListener>();

            services.AddGraphQL()
               .AddSchema<FoodSchema>()
               .AddSystemTextJson()
               .AddValidationRule<InputValidationRule>()
               .AddGraphTypes(typeof(FoodSchema).Assembly)
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

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseGraphiQl();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
