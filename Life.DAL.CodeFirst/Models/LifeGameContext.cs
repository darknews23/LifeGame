using System;
using Microsoft.EntityFrameworkCore;

namespace Life.DAL.CodeFirst.Models
{
    public class LifeGameContext : DbContext
    {
        public LifeGameContext()
        {
        }

        public LifeGameContext(DbContextOptions<LifeGameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Actions> Actions { get; set; }
        public virtual DbSet<AreaTypes> AreaTypes { get; set; }
        public virtual DbSet<Directions> Directions { get; set; }
        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<GameObjects> GameObjects { get; set; }
        public virtual DbSet<GameObjectsMoveTypes> GameObjectsMoveTypes { get; set; }
        public virtual DbSet<GameObjectsSessionState> GameObjectsSessionState { get; set; }
        public virtual DbSet<GameObjectsStepState> GameObjectsStepState { get; set; }
        public virtual DbSet<GameObjectsTypes> GameObjectsTypes { get; set; }
        public virtual DbSet<GameTiles> GameTiles { get; set; }
        public virtual DbSet<GenderTypes> GenderTypes { get; set; }
        public virtual DbSet<MoveTypes> MoveTypes { get; set; }
        public virtual DbSet<Sessions> Sessions { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Steps> Steps { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=.\;Database=LifeGame;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actions>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AreaTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Directions>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Events>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.GameObjectId1).HasColumnName("GameObjectID1");

                entity.Property(e => e.GameObjectId2).HasColumnName("GameObjectID2");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_Actions");

                entity.HasOne(d => d.GameObjectId1Navigation)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.GameObjectId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_GameObjectsStepState");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Events)
                    .HasForeignKey<Events>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Events_MoveTypes");
            });

            modelBuilder.Entity<GameObjects>(entity =>
            {
                entity.HasOne(d => d.Action)
                    .WithMany(p => p.GameObjects)
                    .HasForeignKey(d => d.ActionId)
                    .HasConstraintName("FK_GameObjects_Actions");

                entity.HasOne(d => d.HabitatNavigation)
                    .WithMany(p => p.GameObjects)
                    .HasForeignKey(d => d.Habitat)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjects_AreaTypes");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GameObjects)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjects_GameObjectsTypes");
            });

            modelBuilder.Entity<GameObjectsMoveTypes>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectId, e.MoveTypeId });

                entity.HasOne(d => d.GameObject)
                    .WithMany(p => p.GameObjectsMoveTypes)
                    .HasForeignKey(d => d.GameObjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsMoveTypes_GameObjects");

                entity.HasOne(d => d.MoveType)
                    .WithMany(p => p.GameObjectsMoveTypes)
                    .HasForeignKey(d => d.MoveTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsMoveTypes_MoveTypes");
            });

            modelBuilder.Entity<GameObjectsSessionState>(entity =>
            {
                entity.HasOne(d => d.Session)
                    .WithMany(p => p.GameObjectsSessionState)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsSessionState_Sessions");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GameObjectsSessionState)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsSessionState_GameObjectsTypes");
            });

            modelBuilder.Entity<GameObjectsStepState>(entity =>
            {
                entity.HasOne(d => d.GenderType)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.GenderTypeId)
                    .HasConstraintName("FK_GameObjectsStepState_GenderTypes");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsStepState_Statuses");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsStepState_Steps");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.GameObjectsStepState)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameObjectsStepState_GameObjectsTypes");
            });

            modelBuilder.Entity<GameObjectsTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameTiles>(entity =>
            {
                entity.HasOne(d => d.AreaType)
                    .WithMany(p => p.GameTiles)
                    .HasForeignKey(d => d.AreaTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameTiles_AreaTypes");

                entity.HasOne(d => d.Step)
                    .WithMany(p => p.GameTiles)
                    .HasForeignKey(d => d.StepId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameTiles_Steps");
            });

            modelBuilder.Entity<GenderTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MoveTypes>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sessions>(entity =>
            {
                entity.Property(e => e.Created).HasColumnType("datetime");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Steps>(entity =>
            {
                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Steps)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Steps_Sessions");
            });
        }
    }
}
