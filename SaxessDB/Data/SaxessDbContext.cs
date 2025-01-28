using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SaxessDB.Models;

namespace SaxessDB.Data;

public partial class SaxessDbContext : DbContext
{
    public SaxessDbContext()
    {
    }

    public SaxessDbContext(DbContextOptions<SaxessDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Booking> Bookings { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<EmployeeTreatment> EmployeeTreatments { get; set; }

    public virtual DbSet<Treatment> Treatments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost;Database=SaxessDB;Integrated Security=True;Trust Server Certificate=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Booking>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Booking__3214EC2734B04D04");

            entity.ToTable("Booking");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.TimeSlot).HasColumnType("datetime");

            entity.HasOne(d => d.Customer).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Booking__Treatme__3F466844");

            entity.HasOne(d => d.Employee).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__Booking__Employe__403A8C7D");

            entity.HasOne(d => d.Treatment).WithMany(p => p.Bookings)
                .HasForeignKey(d => d.TreatmentId)
                .HasConstraintName("FK__Booking__Treatme__412EB0B6");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC27D90CDB1F");

            entity.HasIndex(e => e.DoB, "UQ__Customer__C0308C8F0B182528").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2724DC1F53");

            entity.HasIndex(e => e.DoB, "UQ__Employee__C0308C8F17EEE604").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<EmployeeTreatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC2783900FFE");

            entity.ToTable("EmployeeTreatment");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.EmployeeId).HasColumnName("EmployeeID");
            entity.Property(e => e.TreatmentId).HasColumnName("TreatmentID");

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeTreatments)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK__EmployeeT__Treat__440B1D61");

            entity.HasOne(d => d.Treatment).WithMany(p => p.EmployeeTreatments)
                .HasForeignKey(d => d.TreatmentId)
                .HasConstraintName("FK__EmployeeT__Treat__44FF419A");
        });

        modelBuilder.Entity<Treatment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Treatmen__3214EC27AC6D082C");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
