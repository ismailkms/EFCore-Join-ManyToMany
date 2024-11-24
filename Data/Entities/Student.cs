namespace EFCore_Join_ManyToMany.Data.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string NameSurname { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
