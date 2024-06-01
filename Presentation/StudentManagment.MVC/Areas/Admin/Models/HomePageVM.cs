
using StudentManagment.Application.DTOs;
namespace StudentManagment.MVC.Areas.Admin.Models;
public class HomePageVM
{
    public List<TeacherDTO> Teachers { get; set; }
    public List<ExamDTO> Exams{ get; set; }
    public List<StudentDTO> Students { get; set; }

	public HomePageVM(List<TeacherDTO> teachers, List<ExamDTO> exams, List<StudentDTO> students)
	{
		Teachers = teachers;
		Exams = exams;
		Students = students;
	}
}
