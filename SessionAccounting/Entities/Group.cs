namespace SessionAccounting.Entities
{
    public class Group : BaseEntity
    {
        public string Name { get; set; }
        public Faculty Faculty { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
