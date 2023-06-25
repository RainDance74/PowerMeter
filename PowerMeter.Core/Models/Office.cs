using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace PowerMeter.Core.Models;

[Table("offices")]
[Index(nameof(RoomNumber), Name = "offices_room_number_key", IsUnique = true)]
public partial class Office
{
    public Office()
    {
        EnergyConsumptions = new HashSet<EnergyConsumption>();
        Payments = new HashSet<Payment>();
        Users = new HashSet<User>();
    }
#nullable enable
    [Key]
    [Column("office_id")]
    public int Id { get; set; }

    [Column("room_number")]
    [StringLength(5)]
    public string? RoomNumber { get; set; }

    [Column("office_name")]
    [StringLength(50)]
    public string? Name { get; set; }

    [NotMapped]
    public string NameAndRoom => (string.IsNullOrEmpty(Name) ? "Undefined" : Name) + (string.IsNullOrEmpty(RoomNumber) ? "" : $" (#{RoomNumber})");


    [InverseProperty(nameof(EnergyConsumption.Office))]
    public virtual ICollection<EnergyConsumption> EnergyConsumptions { get; set; }

    [InverseProperty(nameof(Payment.Office))]
    public virtual ICollection<Payment> Payments { get; set; }

    [InverseProperty(nameof(User.Office))]
    public virtual ICollection<User> Users { get; set; }
}