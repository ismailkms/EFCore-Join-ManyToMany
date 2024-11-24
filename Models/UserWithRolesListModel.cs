using EFCore_Join_ManyToMany.Data.Entities;

namespace EFCore_Join_ManyToMany.Models
{
    public class UserWithRolesListModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public List<Role> Roles { get; set; }
    }
}
