using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class HrmsIntegrationContext : DbContext
    {
        public HrmsIntegrationContext()
        {
        }

        public HrmsIntegrationContext(DbContextOptions<HrmsIntegrationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TimeSheet> TimeSheet { get; set; }
        public virtual DbSet<TimeSheetEntry> TimeSheetEntry { get; set; }
        public virtual DbSet<TimeSheetItem> TimeSheetItem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=CYG365;Database=HrmsIntegration;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeSheet>(entity =>
            {
                entity.HasKey(e => e.Empid);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empname)
                    .HasColumnName("empname")
                    .HasMaxLength(80)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<TimeSheetEntry>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Company)
                    .HasColumnName("company")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Customer)
                    .HasColumnName("customer")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Project)
                    .HasColumnName("project")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Task)
                    .HasColumnName("task")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Timestampid).HasColumnName("timestampid");

                entity.HasOne(d => d.Timestamp)
                    .WithMany(p => p.TimeSheetEntry)
                    .HasForeignKey(d => d.Timestampid)
                    .HasConstraintName("FK_TimeSheetEntry_TimeSheetItem");
            });

            modelBuilder.Entity<TimeSheetItem>(entity =>
            {
                entity.HasKey(e => e.Timestampid);

                entity.Property(e => e.Timestampid).HasColumnName("timestampid");

                entity.Property(e => e.Date)
                    .HasColumnName("date")
                    .HasColumnType("date");

                entity.Property(e => e.Day)
                    .HasColumnName("day")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Empid)
                    .HasColumnName("empid")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.From)
                    .HasColumnName("from")
                    .HasColumnType("date");

                entity.Property(e => e.Hours).HasColumnName("hours");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Submittedto)
                    .HasColumnName("submittedto")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.To)
                    .HasColumnName("to")
                    .HasColumnType("date");

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.TimeSheetItem)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK_TimeSheetItem_TimeSheet");
            });
        }
    }
}
