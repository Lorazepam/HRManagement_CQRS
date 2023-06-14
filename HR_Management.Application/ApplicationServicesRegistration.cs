﻿using HR_Management.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfile));
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
