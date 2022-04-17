using Microsoft.EntityFrameworkCore;

namespace CoreAPIExercise.Models
{
    public partial class Core3APIExerciseContext : DbContext
    {
        public Core3APIExerciseContext()
        {
        }

        public Core3APIExerciseContext(DbContextOptions<Core3APIExerciseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Division> Division { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<JobTitle> JobTitle { get; set; }
        public virtual DbSet<TodoList> TodoList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Division>(entity =>
            {
                entity.Property(e => e.DivisionId).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).ValueGeneratedNever();

                entity.Property(e => e.Account).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.HasKey(e => e.JobTitle1);

                entity.Property(e => e.JobTitle1)
                    .HasColumnName("JobTitle")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TodoList>(entity =>
            {
                entity.HasKey(e => e.TodoId);

                entity.Property(e => e.TodoId).ValueGeneratedNever();

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdateEmployeeId).HasColumnName("UpdateEmployeeID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
