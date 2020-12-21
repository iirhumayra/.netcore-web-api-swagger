using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace elearningWebAPI.Models
{
    public partial class elearningContext : DbContext
    {
        public elearningContext()
        {
        }

        public elearningContext(DbContextOptions<elearningContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=localhost;Database=elearning;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.SubjectDesc)
                    .HasColumnName("subject_desc")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .HasColumnName("subject_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
