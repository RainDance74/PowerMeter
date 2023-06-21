using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PowerMeter.Core.Models;

[Table("recommendations")]
public partial class Recommendation
{
#nullable enable
    [Key]
    [Column("recommendation_id")]
    public int RecommendationId { get; set; }
    [Column("title")]
    [StringLength(100)]
    public string Title { get; set; } = null!;
    [Column("description")]

    public string? Description { get; set; }
    [Column("emoji")]
    [StringLength(10)]
    public string? Emoji { get; set; }
    [Column("created_at", TypeName = "timestamp without time zone")]
    public DateTime CreatedAt { get; set; }
    [Column("created_by")]
    public int? CreatedBy { get; set; }

    [ForeignKey(nameof(CreatedBy))]
    [InverseProperty(nameof(User.Recommendations))]
    public virtual User? CreatedByNavigation { get; set; }
}
