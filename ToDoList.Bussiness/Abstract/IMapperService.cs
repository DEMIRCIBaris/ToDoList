using AutoMapper;

namespace ToDoList.Bussiness.Abstract
{
    public interface IMapperService
    {
        IMapper Mapper { get; }
    }
}
