namespace EFCore_Join_ManyToMany.Data.Entities
{
    public class Lesson
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}
