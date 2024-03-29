﻿using DAL.Context;
using DAL.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.Extensions
{
    public static class DALInjecting
    {
        public static void InjectDAL(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUoW, UoW.UoW>();

            services.AddDbContext<NetmailChatDatabaseContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionString"]);
                options.EnableSensitiveDataLogging();
            });
        }
    }
}
