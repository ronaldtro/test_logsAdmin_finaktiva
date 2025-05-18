using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace log_events_admin_api.Models;

public partial class RegistrationContext : DbContext
{
    public RegistrationContext()
    {
    }

    public RegistrationContext(DbContextOptions<RegistrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EventLog> EventLogs { get; set; }

    public virtual DbSet<EventType> EventTypes { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EventLog>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__event_lo__3213E83F19E226F8");

            entity.ToTable("event_log");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EventDate)
                .HasColumnType("datetime")
                .HasColumnName("event_date");
            entity.Property(e => e.EventDescription)
                .IsUnicode(false)
                .HasColumnName("event_description");
            entity.Property(e => e.EventTypeId).HasColumnName("event_type_id");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");

            entity.HasOne(d => d.EventType).WithMany(p => p.EventLogs)
                .HasForeignKey(d => d.EventTypeId)
                .HasConstraintName("fk_eventlog_eventtype");
        });

        modelBuilder.Entity<EventType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__event_ty__3213E83FEF9C0B4A");

            entity.ToTable("event_type");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnType("datetime")
                .HasColumnName("created_at");
            entity.Property(e => e.EventTypeDescription)
                .IsUnicode(false)
                .HasColumnName("event_type_description");
            entity.Property(e => e.EventTypeName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("event_type_name");
            entity.Property(e => e.UpdatedAt)
                .HasDefaultValueSql("(sysdatetime())")
                .HasColumnName("updated_at");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
