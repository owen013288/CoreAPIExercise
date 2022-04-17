using AutoMapper;
using CoreAPIExercise.Dtos;
using CoreAPIExercise.Models;

namespace CoreAPIExercise.Profiles
{
    // using AutoMapper; => Profile
    public class TodoListProfile : Profile
    {
        public TodoListProfile()
        {
            // 前面 轉換 後面
            CreateMap<TodoList, TodoListSelectDto>()
                .ForMember
                (
                    a => a.InsertEmployeeName,
                    b => b.MapFrom(c => c.InsertEmployee.Name)
                )
                .ForMember
                (
                    a => a.UpdateEmployeeName,
                    b => b.MapFrom(c => c.UpdateEmployee.Name)
                );
        }
    }
}
