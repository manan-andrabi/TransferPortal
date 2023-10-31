
using Microsoft.Extensions.DependencyInjection;
using TransferPortal.Application.Abstraction.IService;
using TransferPortal.Application.Abstraction.Service;

namespace TransferPortal.Application
{
    public static class AssemblyRefrence
    {
        public static IServiceCollection AppLayer(this IServiceCollection service)
        {
            service.AddScoped<ITeacherService , TeacherService > ();
            return service; 
        }

    }
}