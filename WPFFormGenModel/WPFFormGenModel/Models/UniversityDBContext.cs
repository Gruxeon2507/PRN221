using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace WPFFormGenModel.Models
{
    public partial class UniversityDBContext : DbContext
    {
        public UniversityDBContext()
        {
        }

        public UniversityDBContext(DbContextOptions<UniversityDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Major> Majors { get; set; } = null!;
        public virtual DbSet<Student> Students { get; set; } = null!;
        public virtual DbSet<Studentif> Studentifs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var ConnectionString = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(ConnectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Major>(entity =>
            {
                entity.ToTable("Major");

                entity.Property(e => e.Comment)
                    .HasMaxLength(100)
                    .HasColumnName("comment");

                entity.Property(e => e.Credit)
                    .HasMaxLength(50)
                    .HasColumnName("credit");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("Student");

                entity.Property(e => e.Dob)
                    .HasColumnType("date")
                    .HasColumnName("dob");

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Major).HasColumnName("major");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.HasOne(d => d.MajorNavigation)
                    .WithMany(p => p.Students)
                    .HasForeignKey(d => d.Major)
                    .HasConstraintName("FK_Student_Major");
            });

            modelBuilder.Entity<Studentif>(entity =>
            {
                entity.HasKey(e => e.Rollnumber);

                entity.ToTable("Studentif");

                entity.Property(e => e.Rollnumber)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Dateofbirth)
                    .HasColumnType("date")
                    .HasColumnName("dateofbirth");

                entity.Property(e => e.StudentName)
                    .HasMaxLength(50)
                    .HasColumnName("studentName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
