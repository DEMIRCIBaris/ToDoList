using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Bussiness.ValidationRules.FluentValidation.AppUser;
using ToDoList.Entities.DTO.AppUserDTO;

namespace ToDoList.Bussiness.Extensions.ValidationConfig
{
    public static class ValidationConfiguration
    {
        public static void ValidatorConfig(this IServiceCollection services)
        {
            services.AddTransient<IValidator<UserAddDto>, UserAddValidator>();
            services.AddTransient<IValidator<UserSignInDto>, UserSignInValidator>();
        }
    }
}
