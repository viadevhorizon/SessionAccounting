namespace SessionAccounting.Entities
{
    public class Exam : BaseEntity
    {
        public Subject Subject { get; set; }
        public Lector Lector { get; set; }
        public ICollection<ExamStudentAttendance> StudentAttendances { get; set;}
    }
}
