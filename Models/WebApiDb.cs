using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Models
{
    public partial class WebApiDb : DbContext
    {
        public WebApiDb()
        {
        }

        public WebApiDb(DbContextOptions<WebApiDb> options)
            : base(options)
        {
        }

        public virtual DbSet<Exercise> Exercise { get; set; }
        public virtual DbSet<ExerciseData> ExerciseData { get; set; }
        public virtual DbSet<Plan> Plan { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=wop-dev.mysql.database.azure.com;database=woplanner;user=wopadmin@wop-dev;password=jVP52rRnSvuTZQK2MnHUFuxV;treattinyasboolean=true", x => x.ServerVersion("5.7.29-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exercise>(entity =>
            {
                entity.ToTable("exercise");

                entity.HasIndex(e => e.PlanId)
                    .HasName("plan_id_idx");

                entity.Property(e => e.ExerciseId)
                    .HasColumnName("exercise_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExerciseDesc)
                    .HasColumnName("exercise_desc")
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.ExerciseName)
                    .HasColumnName("exercise_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Plan)
                    .WithMany(p => p.Exercise)
                    .HasForeignKey(d => d.PlanId)
                    .HasConstraintName("plan_id");
            });

            modelBuilder.Entity<ExerciseData>(entity =>
            {
                entity.HasKey(e => e.IdexerciseDataId)
                    .HasName("PRIMARY");

                entity.ToTable("exercise_data");

                entity.HasIndex(e => e.ExerciseId)
                    .HasName("exercise_data_idx");

                entity.Property(e => e.IdexerciseDataId)
                    .HasColumnName("idexercise_data_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.ExerciseData1)
                    .HasColumnName("exercise_data")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.ExerciseId)
                    .HasColumnName("exercise_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Exercise)
                    .WithMany(p => p.ExerciseData)
                    .HasForeignKey(d => d.ExerciseId)
                    .HasConstraintName("exercise_data");
            });

            modelBuilder.Entity<Plan>(entity =>
            {
                entity.ToTable("plan");

                entity.HasIndex(e => e.UserId)
                    .HasName("user_id_idx");

                entity.Property(e => e.PlanId)
                    .HasColumnName("plan_id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.PlanDesc)
                    .HasColumnName("plan_desc")
                    .HasColumnType("tinytext")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.PlanName)
                    .HasColumnName("plan_name")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Plan)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("user_id2");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("email_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Username)
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(225)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Password)
                    .HasColumnName("password")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Token)
                    .HasColumnName("token")
                    .HasColumnType("varchar(255)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasColumnType("varchar(45)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_danish_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
