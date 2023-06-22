using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace PowerMeter.Core.Models;

[Table("departments")]
[Index(nameof(DepartmentName), Name = "departments_department_name_key", IsUnique = true)]
public partial class Department
{
    public Department()
    {
        Users = new HashSet<User>();
    }

    [Key]
    [Column("department_id")]
    public int Id { get; set; }
    [Column("department_name")]
    [StringLength(50)]
    public string DepartmentName { get; set; } = null!;

    [InverseProperty(nameof(User.Department))]
    public virtual ICollection<User> Users { get; set; }
}
