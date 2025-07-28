using TheEasyBazar.Data.IRepositories;
using TheEasyBazar.Data.Repositories;
using TheEasyBazar.Service.Interfaces;
using TheEasyBazar.Service.Services;

namespace TheEasyBazar.API.Extensions;

public static class ServcieExtensions
{
    public static void AddCustomService(this IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}
