using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Life.DAL.DatabaseFirst.Models
{
    public partial class LifeGameDBContext : DbContext
    {
        public LifeGameDBContext()
        {
        }

        public LifeGameDBContext(DbContextOptions<LifeGameDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<GameObjectsSessionTypes> GameObjectsSessionTypes { get; set; }
        public virtual DbSet<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual DbSet<GameObjectsTypes> GameObjectsTypes { get; set; }
        public virtual DbSet<GameTiles> GameTiles { get; set; }
        public virtual DbSet<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual DbSet<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Steps> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\;Database=LifeGameDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Events>(entity =>
            {
                entity.HasOne(d => d.Step)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Steps");
            });

            modelBuilder.Entity<GameObjectsSessionTypes>(entity =>
            {
                entity.HasKey(e => new { e.TypeName, e.SessionId });

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GameObjectsSessionTypes)
                    .HasForeignKey(d => d.TypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsSessionTypes_GameObjectsTypes");
            });

            modelBuilder.Entity<GameObjectsStepState>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectId, e.TypeName, e.StepId });

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsStepState_Steps");
                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.TypeName)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsStepState_GameObjectsTypes");
            });

            modelBuilder.Entity<GameObjectsTypes>(entity =>
            {
                entity.HasKey(e => e.TypeName);

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameTiles>(entity =>
            {
                entity.HasKey(e => new { e.StepId, e.X, e.Y })
                    .HasName("PK_GameTiles_1");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.GameTiles)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameTiles_Steps");
            });

            modelBuilder.Entity<SessionPartiallyEatableTypes>(entity =>
            {
                entity.HasKey(e => new { e.TypeName, e.SessionId });

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionPartiallyEatableTypes)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionPartiallyEatableTypes_Sessions");
            });

            modelBuilder.Entity<SessionTypesMoveTypes>(entity =>
            {
                entity.HasKey(e => new { e.TypeName, e.MoveTypeId, e.SessionId });

                entity.Property(e => e.TypeName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.SessionTypesMoveTypes)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SessionTypesMoveTypes_Sessions");
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<Steps>(entity =>
            {
                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Steps_Sessions");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
