using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFramework.Mapping
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(i => i.UserName).HasMaxLength(100);
            builder.Property(i => i.Name).HasMaxLength(100);
            builder.Property(i => i.Surname).HasMaxLength(100);

            builder.HasMany(i => i.Events).WithOne(i => i.AppUser).HasForeignKey(i => i.AppUserId);
        }
    }
}
