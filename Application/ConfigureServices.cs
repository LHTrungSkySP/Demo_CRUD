﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Đăng ký MediatR với Assembly hiện tại (Application)
            services.AddMediatR(Assembly.GetExecutingAssembly());
            return services;
        }
    }
}
