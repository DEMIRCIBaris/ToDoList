using Microsoft.Extensions.DependencyInjection;
using ToDoList.Bussiness.Abstract;
using ToDoList.Bussiness.Concrete;
using ToDoList.DataAccess.Abstract;
using ToDoList.DataAccess.Concrete.EntityFramework;

namespace ToDoList.Bussiness.Extensions.DIResolvers
{
    public static class StartupDIResolvers
    {
        public static void AddContainerWithDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserDal, EfAppUserDal>();

            services.AddScoped<IMapperService, MapperService>();

            services.AddScoped<IEventsDal, EfEventDal>();
            services.AddScoped<IEventsService, EventsService>();
        }
    }
}
