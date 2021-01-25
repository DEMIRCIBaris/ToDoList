using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Entities.Concrete;

namespace ToDoList.DataAccess.Concrete.EntityFramework.Mapping
{
    public class EventsMap : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Id).UseIdentityColumn();

            builder.HasOne(i => i.AppUser).WithMany(i => i.Events).HasForeignKey(i => i.AppUserId);
        }
    }
}
