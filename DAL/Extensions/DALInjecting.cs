using DAL.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DALInjecting
    {
        public static void InjectDAL(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<NetmailChatDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
