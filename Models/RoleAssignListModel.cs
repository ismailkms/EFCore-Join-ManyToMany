namespace EFCore_Join_ManyToMany.Models
{
    public class RoleAssignListModel
    {
        public int RoleId { get; set; }
        public string Name { get; set; }
        public bool Exist { get; set; }
        //Bu rolün User'da olup olmadığını tutacağım property'im.
    }
}
