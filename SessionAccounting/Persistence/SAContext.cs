using Microsoft.EntityFrameworkCore;

using SessionAccounting.Entities;

namespace SessionAccounting.Persistence
{
    public class SAContext : DbContext
    {
        public SAContext(DbContextOptions<SAContext> saContextOptions) : base(saContextOptions)
        {
            Database.EnsureCreated();
        }
        public DbSet<Exam>? Exams { get; set; }
        public DbSet<Student>? Students { get; set; }
        public DbSet<ExamStudentAttendance>? ExamStudentAttendances { get; set; }
        public DbSet<Faculty>? Faculties { get; set; }
        public DbSet<Group>? Groups { get; set; }
        public DbSet<Lector>? Lectors { get; set; }
        public DbSet<Subject>? Subjects { get; set; }
        public DbSet<LectorSubject>? LectorSubjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { modelBuilder.Entity<LectorSubject>()
                .HasKey(sa => new { sa.SubjectId, sa.LectorId });

            modelBuilder.Entity<ExamStudentAttendance>()
                .HasKey(sa => new { sa.ExamId, sa.StudentId });


            base.OnModelCreating(modelBuilder);
        }

        public new Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }

}
