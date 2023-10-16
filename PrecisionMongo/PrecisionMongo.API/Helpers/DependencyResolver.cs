using PrecisionMongo.Core.Entities;
using PrecisionMongo.Core.Interfaces;
using PrecisionMongo.Core.Services;
using PrecisionMongo.Infrastructure;
using PrecisionMongo.Infrastructure.Repositories;

namespace PrecisionMongo.API.Helpers
{
    public static class DependencyResolver
    {
        public static IServiceCollection AddDependencies (this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDbSettingsEntity>(configuration.GetSection("MongoDBSettings"));

            #region Todo
            services.AddScoped<ITodoService, TodoService>();
            services.AddScoped<ITodoRepository, TodoRepository>();
            #endregion

            services.AddScoped<IMongoDBContext, MongoDBContext>();

            return services;
        }
    }
}
