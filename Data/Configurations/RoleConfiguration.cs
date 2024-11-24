using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Join_ManyToMany.Data.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        //DbContext içerisindeki OnModelCreating'e buradan ekleme yapabiliyoruz. Yani OnModelCreating'i şişirmeden içerisindeki kalabalığı azaltarak yönetilebilirliği artırıyorum.
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //Role ve UserRole tablolarını OneToMany olarak foreignkey ile bağladım.
            builder.HasMany(u => u.UserRoles).WithOne(ur => ur.Role).HasForeignKey(ur => ur.RoleId);

            //Seed data ekledik
            builder.HasData(
                    new Role() { Id = 1, Name = "Role1" },
                    new Role() { Id = 2, Name = "Role2" },
                    new Role() { Id = 3, Name = "Role3" },
                    new Role() { Id = 4, Name = "Role4" }
                );
        }
    }
}
