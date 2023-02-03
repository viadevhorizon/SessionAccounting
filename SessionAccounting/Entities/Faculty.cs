namespace SessionAccounting.Entities
{
    public class Faculty : BaseEntity
    {
        public string Name {get; set; }

        public ICollection<Group> Groups { get; set; }
    }
}
