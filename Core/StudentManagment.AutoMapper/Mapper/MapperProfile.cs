using AutoMapper;
using StudentManagment.Application.DTOs;
using StudentManagment.Application.Features.Commands.Exam;
using StudentManagment.Application.Features.Commands.Lesson;
using StudentManagment.Application.Features.Commands.Student;
using StudentManagment.Application.Features.Commands.Teacher;
using StudentManagment.Application.Features.Queries.Exam;
using StudentManagment.Application.Features.Queries.Lesson;
using StudentManagment.Application.Features.Queries.Student;
using StudentManagment.Application.Features.Queries.Teacher.GetAllTeacher;
using StudentManagment.Domain.Entities;

namespace StudentManagment.AutoMapper.Mapper;
public class MapperProfile : Profile
{
	public MapperProfile()
	{
		CreateMap<StudentCreateCommandRequest, Student>().ReverseMap();
		CreateMap<TeacherCreateCommandRequest, Teacher>().ReverseMap();
		CreateMap<GetAllTeacherQueryResponse, Teacher>().ReverseMap();
		CreateMap<GetAllLessonQueryResponse, Lesson>().ReverseMap();
		CreateMap<GetAllStudentQueryResponse, Student>().ReverseMap();
		CreateMap<LessonCreateCommandRequest, Lesson>().ReverseMap();
		CreateMap<GetAllExamQueryResponse, Exam>().ReverseMap();
		CreateMap<ExamCreateCommandRequest, Exam>().ReverseMap();
		CreateMap<LessonDTO, Lesson>().ReverseMap();
		CreateMap<TeacherDTO, Teacher>().ReverseMap();
		CreateMap<ExamDTO, Exam>().ReverseMap();
		CreateMap<GetAllTeacherQueryResponse ,  TeacherDTO>().ReverseMap();
		CreateMap<GetAllStudentQueryResponse ,  StudentDTO>().ReverseMap();
		CreateMap<GetAllExamQueryResponse ,  ExamDTO>().ReverseMap();


	}
}
