using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EmployeeManagement.DataAccess.Entities
{
    public partial class EmployeeManagementContext : DbContext
    {
        public EmployeeManagementContext()
        {
        }

        public EmployeeManagementContext(DbContextOptions<EmployeeManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ActualSalary> ActualSalaries { get; set; } = null!;
        public virtual DbSet<AttachedFile> AttachedFiles { get; set; } = null!;
        public virtual DbSet<Claim> Claims { get; set; } = null!;
        public virtual DbSet<RefreshToken> RefreshTokens { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<RoleClaim> RoleClaims { get; set; } = null!;
        public virtual DbSet<Submission> Submissions { get; set; } = null!;
        public virtual DbSet<SubmissionType> SubmissionTypes { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN\\KTEAM;uid=sa;pwd=12345;database=EmployeeManagement;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActualSalary>(entity =>
            {
                entity.Property(e => e.ActualSalaryId).ValueGeneratedNever();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ActualSalaries)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ActualSal__UserI__36B12243");
            });

            modelBuilder.Entity<AttachedFile>(entity =>
            {
                entity.Property(e => e.AttachedFileId).ValueGeneratedNever();

                entity.HasOne(d => d.Submission)
                    .WithMany(p => p.AttachedFiles)
                    .HasForeignKey(d => d.SubmissionId)
                    .HasConstraintName("FK__AttachedF__Submi__3A81B327");
            });

            modelBuilder.Entity<Claim>(entity =>
            {
                entity.Property(e => e.ClaimId).ValueGeneratedNever();

                entity.Property(e => e.ClaimName).HasMaxLength(50);
            });

            modelBuilder.Entity<RefreshToken>(entity =>
            {
                entity.Property(e => e.RefreshTokenId).ValueGeneratedNever();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.ExpirationDate).HasColumnType("datetime");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.RefreshTokens)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__RefreshTo__UserI__37A5467C");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<RoleClaim>(entity =>
            {
                entity.HasKey(e => e.RoleClaims)
                    .HasName("PK__RoleClai__6D815012315D6DA1");

                entity.Property(e => e.RoleClaims).ValueGeneratedNever();

                entity.HasOne(d => d.Claim)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.ClaimId)
                    .HasConstraintName("FK__RoleClaim__Claim__35BCFE0A");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.RoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__RoleClaim__RoleI__34C8D9D1");
            });

            modelBuilder.Entity<Submission>(entity =>
            {
                entity.Property(e => e.SubmissionId).ValueGeneratedNever();

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.SubmissionType)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.SubmissionTypeId)
                    .HasConstraintName("FK__Submissio__Submi__398D8EEE");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Submissions)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Submissio__UserI__38996AB5");
            });

            modelBuilder.Entity<SubmissionType>(entity =>
            {
                entity.Property(e => e.SubmissionTypeId).ValueGeneratedNever();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).ValueGeneratedNever();

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.RefreshToken).HasMaxLength(50);

                entity.Property(e => e.RoleId).HasColumnName("roleId");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TokenCreated).HasColumnType("datetime");

                entity.Property(e => e.TokenExpires).HasColumnType("datetime");

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("FK__Users__roleId__33D4B598");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
