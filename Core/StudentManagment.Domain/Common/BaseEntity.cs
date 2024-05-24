namespace StudentManagment.Domain.Common;
public class BaseEntity : IBaseEntity
{
    public bool IsDeleted { get; set; } = false;
    public DateTime CreatedDate = DateTime.Now;
    public DateTime UpdatedDate { get; set; }
}
