
using EFCore_Join_ManyToMany.Data.Configurations;
using EFCore_Join_ManyToMany.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCore_Join_ManyToMany.Data.Context
{
    public class JoinDbContext : DbContext
    {
        public JoinDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lesson> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //IEntityTypeConfiguration<>'dan implement ederek oluşturmuş olduğum configurationları çağırıyorum. Direk burada FluentApi'lerimide yazabilirim ya da bu şekilde kendi oluşturduğum configurationları çağırabilirim.

            //User ve Role arasındaki ManyToMany ilişkiyi kurarken bir ara tablo oluşturdum ve bu ara tablo ile User ve Role arasında OneToMany ilşki kurdum.
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());

            //Student ve Lesson arasındaki ManyToMany ilişkiyi Student içerisinde public List<Lesson> Lessons { get; set; } navigation propertysini ve Lesson içerisinde public List<Student> Students { get; set; } navigation propertysini yazarak sağladım. Her hangi bir ara tablo oluşturmadım ama EFCore db tarafında kendi oluşturdu.
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new LessonConfiguration());
        }
    }
}
