namespace StudentManagment.Application.Features.Queries.Exam;
public class GetAllExamQueryResponse
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public decimal Price { get; set; }
    public string? LessonName { get; set; }
    public bool isDeleted { get; set; }
}
