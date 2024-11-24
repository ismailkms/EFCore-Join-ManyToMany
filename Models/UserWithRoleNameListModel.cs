using EFCore_Join_ManyToMany.Data.Entities;

namespace EFCore_Join_ManyToMany.Models
{
    public class UserWithRoleNameListModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string RoleName { get; set; }
    }
}
