using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        //DbContext içerisindeki OnModelCreating'e buradan ekleme yapabiliyoruz. Yani OnModelCreating'i şişirmeden içerisindeki kalabalığı azaltarak yönetilebilirliği artırıyorum.
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            //Seed data ekledik
            builder.HasData(
                    new Student() { Id = 1, NameSurname = "Student1" },
                    new Student() { Id = 2, NameSurname = "Student2" },
                    new Student() { Id = 3, NameSurname = "Student3" },
                    new Student() { Id = 4, NameSurname = "Student4" }
                );
        }
    }
}