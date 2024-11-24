namespace EFCore_Join_ManyToMany.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public List<UserRole> UserRoles { get; set; }
    }
}
