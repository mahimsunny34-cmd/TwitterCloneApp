using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using TwitterClone.Infrastratcure.Persistance;

namespace TwitterClone.Infrastratcure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            if(string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            }
            services.AddDbContext<TwitterCloneDbContext>(options =>
                options.UseNpgsql(connectionString));
            return services;
        }
    }
}
