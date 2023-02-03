namespace SessionAccounting.Entities
{
    public class LectorSubject
    {
        public Lector Lector { get; set; }

        public Subject Subject { get; set; }

        public Guid LectorId { get; set; }
        public Guid SubjectId { get; set; }
    }
}
