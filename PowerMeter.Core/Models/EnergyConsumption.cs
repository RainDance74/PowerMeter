using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PowerMeter.Core.Models;

[Table("energy_consumptions")]
public partial class EnergyConsumption
{
    [Key]
    [Column("consumption_id")]
    public int Id { get; set; }
    [Column("office_id")]
    public int OfficeId { get; set; }
    [Column("timestamp", TypeName = "timestamp without time zone")]
    public DateTime Timestamp { get; set; }
    [Column("consumption_value")]
    public float ConsumptionValue { get; set; }

    [ForeignKey(nameof(OfficeId))]
    [InverseProperty("EnergyConsumptions")]
    public virtual Office Office { get; set; } = null!;
}