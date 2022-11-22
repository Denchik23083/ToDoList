using AutoMapper;
using ToDoList.Db.Entities;
using ToDoList.Web.Models;

namespace ToDoList.Web.Utilities
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<ProblemModel, Problem>();
            CreateMap<Problem, ProblemModel>();
        }
    }
}
