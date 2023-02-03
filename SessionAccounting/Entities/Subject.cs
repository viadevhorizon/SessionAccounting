namespace SessionAccounting.Entities
{
    public class Subject : BaseEntity
    {
        public string Name { get; set; }
        public int Credits { get; set; }
        public ICollection<LectorSubject> LectorSubjects { get; set; }
    }
}
