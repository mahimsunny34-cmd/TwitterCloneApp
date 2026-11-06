using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.API.Data;
using TwitterClone.Application.Interfaces;
using TwitterClone.Infrastratcure.Repositories;

namespace TwitterClone.Infrastratcure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<ITweetRepository, TweetRepository>();
            services.AddSingleton<IBookmarkRepository, BookmarksRepository>();
            services.AddSingleton<IRetweetRepository, RetweetRepository>();
            return services;
        }
    }
}
