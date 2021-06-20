using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Life.DAL.Models
{
    public partial class LifeGameDbContext : DbContext
    {
        public LifeGameDbContext()
        {
        }

        public LifeGameDbContext(DbContextOptions<LifeGameDbContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Events> Events { get; set; }
        public virtual DbSet<GoSessionTypes> GoSessionTypes { get; set; }
        public virtual DbSet<GoStepStartState> GoStepStartState { get; set; }
        public virtual DbSet<GoType> GoType { get; set; }
        public virtual DbSet<GameTile> GameTiles { get; set; }
        public virtual DbSet<SessionPartiallyEatableTypes> SessionPartiallyEatableTypes { get; set; }
        public virtual DbSet<SessionTypesMoveTypes> SessionTypesMoveTypes { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Step> Step { get; set; }
        public virtual DbSet<GameObject> GameObject { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json");

            var root = builder.Build();
            var connectionString = root.GetConnectionString("LifeGameDb");

            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connectionString);
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

                entity.HasOne(x => x.ActorObject)
                    .WithMany(x => x.PerformedEvents)
                    .HasForeignKey(x => x.ActorObjectId)
                    .HasConstraintName("FK_Events_ActorObject");

                entity.HasOne(x => x.AffectedObject)
                    .WithMany(x => x.AffectedByEvents)
                    .HasForeignKey(x => x.AffectedObjectId)
                    .HasConstraintName("FK_Events_AffectedObject");
            });

            modelBuilder.Entity<GameObject>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(x => x.Type)
                    .WithMany(x => x.GameObjects)
                    .HasForeignKey(x => x.TypeId)
                    .HasConstraintName("FK_GameObject_GoType");

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.GameObjects)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_GameObject_Session");
            });

            modelBuilder.Entity<GameTile>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.GameTiles)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_GameTile_Session");
            });

            modelBuilder.Entity<GoSessionTypes>(entity =>
            {
                entity.HasKey(e => new {e.GameObjectTypeId, e.SessionId});

                entity.HasOne(x => x.GoType)
                    .WithMany(x => x.GameObjectsSessionTypes)
                    .HasForeignKey(x => x.GameObjectTypeId)
                    .HasConstraintName("FK_GoSessionTypes_GoType");

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.GameObjectsSessionTypes)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_GoSessionTypes_Session");
            });

            modelBuilder.Entity<GoStepStartState>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectId, e.StepId });

                entity.HasOne(x => x.GameObject)
                    .WithMany(x => x.GoStepStartStates)
                    .HasForeignKey(x => x.GameObjectId)
                    .HasConstraintName("FK_GoStepStartState_GameObject");

                entity.HasOne(x => x.Step)
                    .WithMany(x => x.GOStepStartStates)
                    .HasForeignKey(x => x.StepId)
                    .HasConstraintName("FK_GoStepStartState_Step");
            });

            modelBuilder.Entity<GoType>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });

            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => new { e.Id });
            });

            modelBuilder.Entity<SessionPartiallyEatableTypes>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectTypeId, e.SessionId });

                entity.HasOne(x => x.GoType)
                    .WithMany(x => x.SessionPartiallyEatableTypes)
                    .HasForeignKey(x => x.GameObjectTypeId)
                    .HasConstraintName("FK_SessionPartiallyEatableTypes_GoType");

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.SessionPartiallyEatableTypes)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_SessionPartiallyEatableTypes_Session");
            });

            modelBuilder.Entity<SessionTypesMoveTypes>(entity =>
            {
                entity.HasKey(e => new { e.GameObjectTypeId, e.SessionId });

                entity.HasOne(x => x.GoType)
                    .WithMany(x => x.SessionTypesMoveTypes)
                    .HasForeignKey(x => x.GameObjectTypeId)
                    .HasConstraintName("FK_SessionTypesMoveTypes_GoType");

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.SessionTypesMoveTypes)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_SessionTypesMoveTypes_Session");
            });

            modelBuilder.Entity<Step>(entity =>
            {
                entity.HasKey(e => new { e.Id });

                entity.HasOne(x => x.Session)
                    .WithMany(x => x.Steps)
                    .HasForeignKey(x => x.SessionId)
                    .HasConstraintName("FK_Step_Session");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
