using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCore_Join_ManyToMany.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        //DbContext içerisindeki OnModelCreating'e buradan ekleme yapabiliyoruz. Yani OnModelCreating'i şişirmeden içerisindeki kalabalığı azaltarak yönetilebilirliği artırıyorum.
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasMany(u => u.UserRoles).WithOne(ur => ur.User).HasForeignKey(ur => ur.UserId);
            //User ve UserRole tablolarını OneToMany olarak foreignkey ile bağladım.

            //Seed data ekledik
            builder.HasData(
                    new User() { Id = 1, Username = "user1", Password = "123" },
                    new User() { Id = 2, Username = "user2", Password = "123" },
                    new User() { Id = 3, Username = "user3", Password = "123" },
                    new User() { Id = 4, Username = "user4", Password = "123" }
                );
        }
    }
}
