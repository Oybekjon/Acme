using Acme.Services;
using Acme.Services.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.Web.ActionHelpers
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IInstantMessage<TextMessage>, InstantMessage<TextMessage>>();
            services.AddSingleton<IInstantMessage<ChatInfo>, InstantMessage<ChatInfo>>();
            services.AddScoped<ITextMessaging, TextMessaging>();
        }
    }
}
