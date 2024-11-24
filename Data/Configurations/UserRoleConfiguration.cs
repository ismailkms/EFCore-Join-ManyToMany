using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Join_ManyToMany.Data.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        //DbContext içerisindeki OnModelCreating'e buradan ekleme yapabiliyoruz. Yani OnModelCreating'i şişirmeden içerisindeki kalabalığı azaltarak yönetilebilirliği artırıyorum.
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(ur => new {ur.UserId, ur.RoleId});
            //İki kolonuda primarykey yaptım.
        }
    }
}
