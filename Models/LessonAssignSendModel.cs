namespace EFCore_Join_ManyToMany.Models
{
    public class LessonAssignSendModel
    {
        public List<LessonAssignListModel> Lessons { get; set; }
        public int StudentId { get; set; }
    }
}
