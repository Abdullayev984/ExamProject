using AutoMapper;
using EntityLayer.Concrete;
using EntityLayer.DTOs.ExamDTOs;
using EntityLayer.DTOs.LessonDTOs;
using EntityLayer.DTOs.StudentDTOs;
using EntityLayer.DTOs.UserDTOs;

namespace BusinessLayer.Mapper
{
    public class Automapper : Profile
    {
        public Automapper()
        {

            CreateMap<LessonToAddorUpdateDTO, Lesson>();
            CreateMap<Lesson, LessonToListDTO>();
            CreateMap<StudentToAddorUpdateDTO, Student>();
            CreateMap<StudentToAddorUpdateDTO, StudentToListDTO>().ReverseMap();
            CreateMap<ExamToAddorUpdateDTO, ExamToListDTO>().ReverseMap();
            CreateMap<LessonToAddorUpdateDTO, LessonToListDTO>().ReverseMap();
            CreateMap<Student, StudentToListDTO>();
            CreateMap<ExamToAddorUpdateDTO, Exam>();
            CreateMap<Exam, ExamToListDTO>();
        }
    }
}
