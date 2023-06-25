using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using PowerMeter.Core.Enums;
using PowerMeter.Core.Helpers;

namespace PowerMeter.Core.Models;

[Table("users")]
[Index(nameof(Email), Name = "users_email_key", IsUnique = true)]
public partial class User
{
#nullable enable
    public User()
    {
        Recommendations = new HashSet<Recommendation>();
    }

    [Key]
    [Column("user_id")]
    public int Id { get; set; }

    [Column("email")]
    [StringLength(100)]
    public string Email { get; set; } = null!;

    [Column("first_name")]
    [StringLength(50)]
    public string FirstName { get; set; } = null!;

    [Column("last_name")]
    [StringLength(50)]
    public string LastName { get; set; } = null!;

    [Column("patronymic")]
    [StringLength(50)]
    public string? Patronymic { get; set; }

    [NotMapped]
    public string ShortName => $"{LastName} {FirstName[0]}. {(Patronymic?.Length > 0 ? Patronymic[0].ToString() + "." : "")}".Trim();

    [NotMapped]
    public string FullName => $"{LastName} {FirstName} {Patronymic ?? ""}".Trim();

    [Column("department_id")]
    public int DepartmentId { get; set; }

    [Column("status")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserStatus Status { get; set; }

    [Column("image_url")]
    [StringLength(255)]
    public string? ImageUrl { get; set; }

    [Column("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserRole Role { get; set; }

    [Column("office_id")]
    public int? OfficeId { get; set; } = 1;

    [Column("note")]
    public string? Note { get; set; }


    [ForeignKey(nameof(DepartmentId))]
    [InverseProperty("Users")]
    public virtual Department Department { get; set; } = null!;

    [ForeignKey(nameof(OfficeId))]
    [InverseProperty("Users")]
    public virtual Office? Office { get; set; }

    [InverseProperty(nameof(Recommendation.CreatedByNavigation))]
    public virtual ICollection<Recommendation> Recommendations { get; set; }
}
