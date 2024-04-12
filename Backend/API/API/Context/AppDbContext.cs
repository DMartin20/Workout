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
        public DbSet<ExerciseType> ExerciseTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkoutPlan>()
                .HasOne(wp => wp.User)
                .WithMany(u => u.WorkoutPlans)
                .HasForeignKey(wp => wp.UserId);

            modelBuilder.Entity<WorkoutExercise>()
            .HasKey(we => we.Id); // Vegyük fel egyedi kulcsként az "Id" mezőt

            // Módosítsuk a kulcsokhoz tartozó kardinalitást
            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.WorkoutPlan)
                .WithMany(wp => wp.WorkoutExercises)
                .HasForeignKey(we => we.WorkoutId);

            modelBuilder.Entity<WorkoutExercise>()
                .HasOne(we => we.Exercise)
                .WithMany(e => e.WorkoutExercises)
                .HasForeignKey(we => we.ExerciseId);

            modelBuilder.Entity<ExerciseType>()
                .HasKey(et => new { et.ExerciseId, et.TypeId });

            modelBuilder.Entity<ExerciseType>()
                .HasOne(et => et.Exercise)
                .WithMany(e => e.ExerciseTypes)
                .HasForeignKey(et => et.ExerciseId);

            modelBuilder.Entity<ExerciseType>()
                .HasOne(et => et.Type)
                .WithMany(t => t.ExerciseTypes)
                .HasForeignKey(et => et.TypeId);
        }
    }
}
