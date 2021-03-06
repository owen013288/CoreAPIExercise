using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


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
                entity.Property(e => e.DivisionId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.EmployeeId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Account).IsRequired();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Division)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DivisionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Division");

                entity.HasOne(d => d.JobTitle)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.JobTitleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_JobTitle");
            });

            modelBuilder.Entity<JobTitle>(entity =>
            {
                entity.HasKey(e => e.JobTitle1);

                entity.Property(e => e.JobTitle1)
                    .HasColumnName("JobTitle")
                    .HasDefaultValueSql("(newid())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TodoList>(entity =>
            {
                entity.HasKey(e => e.TodoId);

                entity.Property(e => e.TodoId).HasDefaultValueSql("(newid())");

                entity.Property(e => e.InsertTime).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.UpdateEmployeeId).HasColumnName("UpdateEmployeeID");

                entity.Property(e => e.UpdateTime).HasColumnType("datetime");

                entity.HasOne(d => d.InsertEmployee)
                    .WithMany(p => p.TodoListInsertEmployee)
                    .HasForeignKey(d => d.InsertEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TodoList_Employee");

                entity.HasOne(d => d.UpdateEmployee)
                    .WithMany(p => p.TodoListUpdateEmployee)
                    .HasForeignKey(d => d.UpdateEmployeeId)
                    .HasConstraintName("FK_TodoList_Employee1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
