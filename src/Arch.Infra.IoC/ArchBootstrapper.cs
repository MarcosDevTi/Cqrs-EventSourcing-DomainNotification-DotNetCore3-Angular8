using Arch.Handlers;
using Arch.Handlers.AutoMapperProfiles;
using Arch.Handlers.Customer;
using Arch.Handlers.Extensions;
using Arch.Infra.Data;
using Arch.Infra.EventSourcing;
using Arch.Infra.Shared.Configurations;
using Arch.Infra.Shared.Cqrs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Arch.Infra.IoC
{
    public class ArchBootstrapper
    {
        public static void Register(IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<ArchContext>(_ => _.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddDbContext<EventSourcingContext>(_ => _.UseSqlServer(config.GetConnectionString("DefaultConnection")));
            services.AddScoped<IProcessor, Processor>();
            services.AddCqrs(typeof(CustomerCommandHandler));
            services.AddAutoMapper(typeof(CustomerProfilers));
            services.AddSingleton<IConfig, Config>();
        }
    }
}
