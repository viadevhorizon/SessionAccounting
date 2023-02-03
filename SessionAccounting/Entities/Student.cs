namespace SessionAccounting.Entities
{
    public class Student : BaseEntity
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public Group Group { get; set; }
        public ICollection<ExamStudentAttendance> StudentAttendances { get; set; }
    }
}
