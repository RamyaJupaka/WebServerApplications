using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Final_examABC_Employee.Models
{
    public partial class ABCEmployeeJobContext : DbContext
    {
        public ABCEmployeeJobContext()
        {
        }

        public ABCEmployeeJobContext(DbContextOptions<ABCEmployeeJobContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employees> Employees { get; set; }
        public virtual DbSet<JobAssignments> JobAssignments { get; set; }
        public virtual DbSet<Jobs> Jobs { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employees>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<JobAssignments>(entity =>
            {
                entity.HasKey(e => e.JobAssignmentsId)
                    .HasName("PK__JobAssig__F96CDECB480D0807");

                entity.Property(e => e.AssignemtDate).HasMaxLength(50);

                entity.Property(e => e.JobCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNavigation)
                    .WithMany(p => p.JobAssignments)
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK_dbo.JobAssignments_dbo.Employees_Id");

                entity.HasOne(d => d.JobCodeNavigation)
                    .WithMany(p => p.JobAssignments)
                    .HasForeignKey(d => d.JobCode)
                    .HasConstraintName("FK_dbo.JobAssignments_dbo.Jobs_JobCode");
            });

            modelBuilder.Entity<Jobs>(entity =>
            {
                entity.HasKey(e => e.JobCode)
                    .HasName("PK__Jobs__ACF383B9B8432EDC");

                entity.Property(e => e.JobCode).HasMaxLength(50);

                entity.Property(e => e.JobTtile)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.StartDate)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
