using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ToDoList.DataAccess.Concrete.EntityFramework.Mapping;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFramework.Context
{
    public class MyDataContext: IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Database=WorkFlowDB;Server=(localdb)\MSSQLLocalDB;Trusted_Connection=True;"); //Connection String eklendi
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AppUserMap());
            builder.ApplyConfiguration(new EventsMap());
            base.OnModelCreating(builder);
        }

        public DbSet<Event> Events { get; set; }
    }
}
