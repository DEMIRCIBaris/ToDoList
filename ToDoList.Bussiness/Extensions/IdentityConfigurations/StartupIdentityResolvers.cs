using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoList.DataAccess.Concrete.EntityFramework.Context;
using ToDoList.Entities.Concrete;

namespace ToDoList.Bussiness.Extensions.IdentityConfigurations
{
    public static class StartupIdentityResolvers
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            //Identity kütüphanesini ayağa kaldırdık
            services.AddIdentity<AppUser, AppRole>(opt =>
            { //Bu kısımda konfigürasyon ayarlarımızı yapıyoruz

                opt.Password.RequireDigit = false; //Sayı olma zorunluluðunu kaldırdık
                opt.Password.RequireLowercase = false; //Küçük harf zorunluluðunu kaldırdık
                opt.Password.RequiredLength = 1;//Karakter sayısını düşürdük
                opt.Password.RequireNonAlphanumeric = false;//Özel karakter zorunluluðu kaldırdık
                opt.Password.RequireUppercase = false;

            }).AddEntityFrameworkStores<MyDataContext>();
        }

        public static void CookieConfigurations(this IServiceCollection services, string loginPath) //, den sonrası değğer ataması için
        {
            services.ConfigureApplicationCookie(opt =>
            {
                opt.LoginPath = new PathString(loginPath);//Giriş için yönlendirme yaptığımız sayfayı belirledik default değeri Account/login 'dir
                opt.AccessDeniedPath = new PathString("/Home/AccessDenied");
                opt.Cookie.HttpOnly = true;//JS Cookie bilgilerine ulaşamaz
                opt.Cookie.Name = "MyWorkFlowCookie";
                opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;//Http ya Https üzerinden çalışıyor
                opt.ExpireTimeSpan = TimeSpan.FromDays(20); //Cookie kaç gün ayakta kalsın
                opt.Cookie.SameSite = SameSiteMode.Strict; // Cookie paylaşımını engeller
            });
        }
    }
}
