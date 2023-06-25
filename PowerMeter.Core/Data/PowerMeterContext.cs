using System.Configuration;
using Microsoft.EntityFrameworkCore;
using PowerMeter.Core.Enums;
using PowerMeter.Core.Helpers;
using PowerMeter.Core.Models;

namespace PowerMeter.Core.Data;

public partial class PowerMeterContext : DbContext
{
    public virtual DbSet<Department> Departments { get; set; } = null!;
    public virtual DbSet<EnergyConsumption> EnergyConsumptions { get; set; } = null!;
    public virtual DbSet<Office> Offices { get; set; } = null!;
    public virtual DbSet<Payment> Payments { get; set; } = null!;
    public virtual DbSet<Recommendation> Recommendations { get; set; } = null!;
    public virtual DbSet<User> Users { get; set; } = null!;

    public PowerMeterContext()
    {
    }

    public PowerMeterContext(DbContextOptions<PowerMeterContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Attempt to get the connection string from a config file
            // Learn more about specifying the connection string in a config file at https://docs.microsoft.com/dotnet/api/system.configuration.configurationmanager?view=netframework-4.7.2
            optionsBuilder.UseNpgsql(ConfigurationManager.ConnectionStrings["PowerMeterConnectionString"]?.ConnectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresEnum("payment_status",  Enum.GetValues<PaymentStatus>() .Select(x => x.ToFriendlyString()).ToArray())
                    .HasPostgresEnum("user_role",       Enum.GetValues<UserRole>()      .Select(x => x.ToFriendlyString()).ToArray())
                    .HasPostgresEnum("user_status",     Enum.GetValues<UserStatus>()    .Select(x => x.ToFriendlyString()).ToArray());

        modelBuilder.Entity<EnergyConsumption>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("energy_consumptions_pkey");

            entity.HasOne(d => d.Office)
                .WithMany(p => p.EnergyConsumptions)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("energy_consumptions_office_id_fkey");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.Property(e => e.Status)
                .HasConversion(EnumHelper.CreateEnumToStringConverter<PaymentStatus>());

            entity.Property(e => e.Amount).HasPrecision(10, 2);

            entity.HasOne(d => d.Office)
                .WithMany(p => p.Payments)
                .HasForeignKey(d => d.OfficeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("payments_office_id_fkey");
        });

        modelBuilder.Entity<Recommendation>(entity =>
        {
            entity.HasOne(d => d.CreatedByNavigation)
                .WithMany(p => p.Recommendations)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("recommendations_created_by_fkey");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.Property(e => e.Role)
                .HasConversion(EnumHelper.CreateEnumToStringConverter<UserRole>());

            entity.Property(e => e.Status)
                .HasConversion(EnumHelper.CreateEnumToStringConverter<UserStatus>());

            entity.HasOne(d => d.Department)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.DepartmentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("users_department_id_fkey");

            entity.HasOne(d => d.Office)
                .WithMany(p => p.Users)
                .HasForeignKey(d => d.OfficeId)
                .HasConstraintName("users_office_id_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
