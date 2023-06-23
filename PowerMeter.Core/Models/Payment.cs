using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace PowerMeter.Core.Models;

[Table("payments")]
public partial class Payment
{
#nullable enable
    [Key]
    [Column("payment_id")]
    public int Id { get; set; }

    [Column("office_id")]
    public int OfficeId { get; set; }

    [Column("start_time", TypeName = "timestamp without time zone")]
    public DateTime StartTime { get; set; }

    [Column("end_time", TypeName = "timestamp without time zone")]
    public DateTime? EndTime { get; set; }

    [Column("note")]
    public string? Note { get; set; }

    [Column("amount")]
    [Precision(10, 2)]
    public decimal Amount { get; set; }

    [Column("payment_link")]
    [StringLength(255)]
    public string? PaymentLink { get; set; }


    [ForeignKey(nameof(OfficeId))]
    [InverseProperty("Payments")]
    public virtual Office Office { get; set; } = null!;
}