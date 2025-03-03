using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace VisitkaUCR.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Discipline> Disciplines { get; set; }

    public virtual DbSet<Division> Divisions { get; set; }

    public virtual DbSet<Education> Educations { get; set; }

    public virtual DbSet<Faculty> Faculties { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Publication> Publications { get; set; }

    public virtual DbSet<Qualification> Qualifications { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    public virtual DbSet<TeachersDiscipline> TeachersDisciplines { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("achievements_pkey");

            entity.ToTable("achievements", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(30)
                .HasColumnName("category");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Discipline>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("disciplines_pkey");

            entity.ToTable("disciplines", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Division>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("divisions_pkey");

            entity.ToTable("divisions", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdFaculty).HasColumnName("id_faculty");
            entity.Property(e => e.Title)
                .HasMaxLength(150)
                .HasColumnName("title");

            entity.HasOne(d => d.IdFacultyNavigation).WithMany(p => p.Divisions)
                .HasForeignKey(d => d.IdFaculty)
                .HasConstraintName("divisions_id_faculty_fkey");
        });

        modelBuilder.Entity<Education>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("educations_pkey");

            entity.ToTable("educations", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country");
            entity.Property(e => e.EducationInstitution)
                .HasMaxLength(150)
                .HasColumnName("education_institution");
            entity.Property(e => e.FormOfEducation)
                .HasMaxLength(7)
                .HasColumnName("form_of_education");
            entity.Property(e => e.Institute)
                .HasMaxLength(150)
                .HasColumnName("institute");
            entity.Property(e => e.Level)
                .HasMaxLength(50)
                .HasColumnName("level");
            entity.Property(e => e.Speciality)
                .HasMaxLength(150)
                .HasColumnName("speciality");
        });

        modelBuilder.Entity<Faculty>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("faculties_pkey");

            entity.ToTable("faculties", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("positions_pkey");

            entity.ToTable("positions", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.IdDivision).HasColumnName("id_division");
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .HasColumnName("title");

            entity.HasOne(d => d.IdDivisionNavigation).WithMany(p => p.Positions)
                .HasForeignKey(d => d.IdDivision)
                .HasConstraintName("positions_id_division_fkey");
        });

        modelBuilder.Entity<Publication>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("publications_pkey");

            entity.ToTable("publications", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .HasColumnName("title");
        });

        modelBuilder.Entity<Qualification>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("qualifications_pkey");

            entity.ToTable("qualifications", "business_cards");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.City)
                .HasMaxLength(30)
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasMaxLength(20)
                .HasColumnName("country");
            entity.Property(e => e.CourseName)
                .HasMaxLength(200)
                .HasColumnName("course_name");
            entity.Property(e => e.Document)
                .HasMaxLength(255)
                .HasColumnName("document");
            entity.Property(e => e.EducationalInstitution)
                .HasMaxLength(150)
                .HasColumnName("educational_institution");
            entity.Property(e => e.FormOfEducation)
                .HasMaxLength(7)
                .HasColumnName("form_of_education");
            entity.Property(e => e.TrainingPeriod)
                .HasMaxLength(23)
                .IsFixedLength()
                .HasColumnName("training_period");
            entity.Property(e => e.Volume).HasColumnName("volume");
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("teachers_pkey");

            entity.ToTable("teachers", "business_cards");

            entity.HasIndex(e => e.Email, "teachers_email_key").IsUnique();

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasMaxLength(25)
                .HasColumnName("patronymic");
            entity.Property(e => e.Photo).HasColumnName("photo");
            entity.Property(e => e.Surname)
                .HasMaxLength(25)
                .HasColumnName("surname");

            entity.HasMany(d => d.IdAchievements).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersAchievement",
                    r => r.HasOne<Achievement>().WithMany()
                        .HasForeignKey("IdAchievement")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_achievements_id_achievement_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_achievements_id_teacher_fkey"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdAchievement").HasName("teachers_achievements_pkey");
                        j.ToTable("teachers_achievements", "business_cards");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("id_teacher");
                        j.IndexerProperty<int>("IdAchievement").HasColumnName("id_achievement");
                    });

            entity.HasMany(d => d.IdEducations).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersEducation",
                    r => r.HasOne<Education>().WithMany()
                        .HasForeignKey("IdEducation")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_educations_id_education_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_educations_id_teacher_fkey"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdEducation").HasName("teachers_educations_pkey");
                        j.ToTable("teachers_educations", "business_cards");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("id_teacher");
                        j.IndexerProperty<int>("IdEducation").HasColumnName("id_education");
                    });

            entity.HasMany(d => d.IdPositions).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersPosition",
                    r => r.HasOne<Position>().WithMany()
                        .HasForeignKey("IdPosition")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_positions_id_position_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_positions_id_teacher_fkey"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdPosition").HasName("teachers_positions_pkey");
                        j.ToTable("teachers_positions", "business_cards");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("id_teacher");
                        j.IndexerProperty<int>("IdPosition").HasColumnName("id_position");
                    });

            entity.HasMany(d => d.IdPublications).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersPublication",
                    r => r.HasOne<Publication>().WithMany()
                        .HasForeignKey("IdPublication")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_publications_id_publication_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_publications_id_teacher_fkey"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdPublication").HasName("teachers_publications_pkey");
                        j.ToTable("teachers_publications", "business_cards");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("id_teacher");
                        j.IndexerProperty<int>("IdPublication").HasColumnName("id_publication");
                    });

            entity.HasMany(d => d.IdQualifications).WithMany(p => p.IdTeachers)
                .UsingEntity<Dictionary<string, object>>(
                    "TeachersQualification",
                    r => r.HasOne<Qualification>().WithMany()
                        .HasForeignKey("IdQualification")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_qualifications_id_qualification_fkey"),
                    l => l.HasOne<Teacher>().WithMany()
                        .HasForeignKey("IdTeacher")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("teachers_qualifications_id_teacher_fkey"),
                    j =>
                    {
                        j.HasKey("IdTeacher", "IdQualification").HasName("teachers_qualifications_pkey");
                        j.ToTable("teachers_qualifications", "business_cards");
                        j.IndexerProperty<int>("IdTeacher").HasColumnName("id_teacher");
                        j.IndexerProperty<int>("IdQualification").HasColumnName("id_qualification");
                    });
        });

        modelBuilder.Entity<TeachersDiscipline>(entity =>
        {
            entity.HasKey(e => new { e.IdTeacher, e.IdDiscipline }).HasName("teachers_disciplines_pkey");

            entity.ToTable("teachers_disciplines", "business_cards");

            entity.Property(e => e.IdTeacher).HasColumnName("id_teacher");
            entity.Property(e => e.IdDiscipline).HasColumnName("id_discipline");
            entity.Property(e => e.Grade).HasColumnName("grade");

            entity.HasOne(d => d.IdDisciplineNavigation).WithMany(p => p.TeachersDisciplines)
                .HasForeignKey(d => d.IdDiscipline)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teachers_disciplines_id_discipline_fkey");

            entity.HasOne(d => d.IdTeacherNavigation).WithMany(p => p.TeachersDisciplines)
                .HasForeignKey(d => d.IdTeacher)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("teachers_disciplines_id_teacher_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
