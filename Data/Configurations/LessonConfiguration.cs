using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany.Data.Configurations
{
    public class LessonConfiguration : IEntityTypeConfiguration<Lesson>
    {
        //DbContext içerisindeki OnModelCreating'e buradan ekleme yapabiliyoruz. Yani OnModelCreating'i şişirmeden içerisindeki kalabalığı azaltarak yönetilebilirliği artırıyorum.
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            //Seed data ekledik
            builder.HasData(
                    new Lesson() { Id = 1, Name = "Lesson1" },
                    new Lesson() { Id = 2, Name = "Lesson2" },
                    new Lesson() { Id = 3, Name = "Lesson3" },
                    new Lesson() { Id = 4, Name = "Lesson4" }
                );
        }
    }
}
