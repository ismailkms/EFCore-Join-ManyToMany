namespace EFCore_Join_ManyToMany.Models
{
    public class LessonAssignListModel
    {
        public int LessonId { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
        //Bu dersin Student'da olup olmadığını tutacağım property'im.
    }
}
