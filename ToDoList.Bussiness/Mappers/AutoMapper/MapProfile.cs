using AutoMapper;
using ToDoList.Entities.Concrete;
using ToDoList.Entities.DTO.AppUserDTO;

namespace ToDoList.Bussiness.Mappers.AutoMapper
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            #region UserApp
            CreateMap<UserAddDto, AppUser>();
            CreateMap<AppUser, UserAddDto>();

            CreateMap<AppUser, UserSignInDto>();
            CreateMap<UserSignInDto, AppUser>();
            #endregion
        }

    }
}
