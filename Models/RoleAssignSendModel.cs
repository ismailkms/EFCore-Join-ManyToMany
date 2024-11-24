namespace EFCore_Join_ManyToMany.Models
{
    public class RoleAssignSendModel
    {
        public List<RoleAssignListModel> Roles { get; set; }
        public int UserId { get; set; }
    }
}
