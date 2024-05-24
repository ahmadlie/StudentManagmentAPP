using Microsoft.AspNetCore.Identity;
using StudentManagment.Domain.Common;

namespace StudentManagment.Domain.Entities.Identity;
public class AppRole : IdentityRole<int> , IBaseEntity
{
}
