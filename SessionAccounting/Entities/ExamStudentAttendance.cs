namespace SessionAccounting.Entities
{
    public class ExamStudentAttendance
    {
        public Exam Exam { get; set; }
        public Student Student { get; set; }
        public int Ticket { get; set; }
        public int Grade { get; set; }

        public Guid ExamId { get; set; }
        public Guid StudentId { get; set; }
    }
}
