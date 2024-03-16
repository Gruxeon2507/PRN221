using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Assignment03.Models
{
    public partial class PRN221_Assignment3Context : DbContext
    {
        public PRN221_Assignment3Context()
        {
        }

        public PRN221_Assignment3Context(DbContextOptions<PRN221_Assignment3Context> options)
            : base(options)
        {
        }

        public virtual DbSet<AppUser> AppUsers { get; set; } = null!;
        public virtual DbSet<Post> Posts { get; set; } = null!;
        public virtual DbSet<PostCategory> PostCategories { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("server =(local); database =PRN221_Assignment3;uid=duckm;pwd=123456;Trusted_Connection=True;Encrypt=False");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__AppUsers__1788CCAC9CB592AB");

                entity.HasIndex(e => e.Email, "UQ__AppUsers__A9D10534568C3ACD")
                    .IsUnique();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Address)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.Content).HasColumnType("text");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.PublishStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK__Posts__AuthorID__29572725");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Posts__CategoryI__2A4B4B5E");
            });

            modelBuilder.Entity<PostCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__PostCate__19093A2BE5515EC6");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Description).HasColumnType("text");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
