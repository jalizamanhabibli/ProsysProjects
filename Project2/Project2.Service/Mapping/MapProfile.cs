using AutoMapper;
using Project2.Core.Dtos;
using Project2.Core.Entities;

namespace Project2.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Exam, ExamTableDto>().ReverseMap();
            CreateMap<Exam, ExamDto>().ReverseMap();
        }
        
    }
}