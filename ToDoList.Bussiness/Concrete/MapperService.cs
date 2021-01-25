using AutoMapper;
using ToDoList.Bussiness.Abstract;
using ToDoList.Bussiness.Mappers.AutoMapper;

namespace ToDoList.Bussiness.Concrete
{
    public class MapperService : IMapperService
    {
        public IMapper Mapper 
        {
            get
            {
                return ObjectMapper.mymapper;
            }
        }
    }
}
