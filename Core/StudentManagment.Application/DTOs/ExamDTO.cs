namespace StudentManagment.Application.DTOs;
public class ExamDTO
{
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
	public bool isDeleted { get; set; }
    public string LessonName { get; set; }
}
