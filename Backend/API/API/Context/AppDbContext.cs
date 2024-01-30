using API.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Type = API.Models.Domain.Type;

namespace API.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<WorkoutPlan> WorkoutPlans { get; set; }
        public DbSet<Exercise> Exercises { get; set; }
        public DbSet<WorkoutExercise> WorkoutExercises { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Type> Types { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.User)
                .WithMany(u => u.WorkoutPlans)
                .HasForeignKey(wp => wp.UserId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasKey(we => new { we.WorkoutId, we.ExerciseId });

            modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.WorkoutPlan)
            .WithMany(wp => wp.WorkoutExercises)
            .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutExercises)
            .HasForeignKey(we => we.ExerciseId);

            modelBuilder.Entity<Exercise>()
            .HasOne(e => e.Difficulty)
            .WithMany(d => d.Exercises)
            .HasForeignKey(e => e.DifficultyId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasPrincipalKey(t => t.DifficultyId);

            modelBuilder.Entity<Exercise>()
            .HasMany(e => e.Types)
            .WithMany(t => t.Exercises)
            .UsingEntity(j => j.ToTable("ExerciseTypes"));

        }
    }
}
