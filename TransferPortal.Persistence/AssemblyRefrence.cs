using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using TransferPortal.Application.Abstraction.IRepository;
using TransferPortal.Application.Abstraction.IService;
using TransferPortal.Application.Abstraction.Service;
using TransferPortal.Persistence.Data;
using TransferPortal.Persistence.Repository;

namespace TransferPortal.Persistence
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection PerLayer(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ITeacherRepository, TeacherRepository>();
            service.AddDbContextPool<TransferPortalDbContext>(options => options.UseSqlServer(configuration.GetConnectionString(nameof(TransferPortalDbContext))));
            return service;
        }

    }
}