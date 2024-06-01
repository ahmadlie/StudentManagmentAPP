namespace StudentManagment.Application.Features.Queries.Lesson;
public class GetAllLessonQueryResponse
{
    public string Code { get; set; }
    public string Name { get; set; }
    public string Class { get; set; }
    public bool IsDeleted { get; set; }
}
