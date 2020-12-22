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

        public virtual DbSet<Soal> Soals { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Subtema> Subtemas { get; set; }
        public virtual DbSet<User> Users { get; set; }

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
            modelBuilder.Entity<Soal>(entity =>
            {
                entity.ToTable("soal");

                entity.Property(e => e.SoalId)
                    .HasColumnName("soal_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Gambar)
                    .HasColumnName("gambar")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Kunci)
                    .HasColumnName("kunci")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opsi1)
                    .HasColumnName("opsi_1")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opsi2)
                    .HasColumnName("opsi_2")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opsi3)
                    .HasColumnName("opsi_3")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Opsi4)
                    .HasColumnName("opsi_4")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Pertanyaan)
                    .HasColumnName("pertanyaan")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.SubtemaId).HasColumnName("subtema_id");

                entity.HasOne(d => d.Subtema)
                    .WithMany(p => p.Soals)
                    .HasForeignKey(d => d.SubtemaId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("subtema_id_fk");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("subject");

                entity.Property(e => e.SubjectId)
                    .HasColumnName("subject_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.Kelas).HasColumnName("kelas");

                entity.Property(e => e.SubjectDesc)
                    .HasColumnName("subject_desc")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubjectName)
                    .HasColumnName("subject_name")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UrlEbook)
                    .HasColumnName("url_ebook")
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Subtema>(entity =>
            {
                entity.ToTable("subtema");

                entity.Property(e => e.SubtemaId)
                    .HasColumnName("subtema_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.SubjectId).HasColumnName("subject_id");

                entity.Property(e => e.SubtemaDesc)
                    .HasColumnName("subtema_desc")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.SubtemaNama)
                    .HasColumnName("subtema_nama")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Subtemas)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("subject_id_fk");
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
