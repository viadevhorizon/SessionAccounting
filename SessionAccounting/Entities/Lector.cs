namespace SessionAccounting.Entities
{
    public class Lector : BaseEntity
    {
        public string Lastname { get; set; }
        public string Firstname { get; set; }
        public string Patronymic { get; set; }
        public ICollection<LectorSubject> LectorSubjects { get; set; }
    }
}
