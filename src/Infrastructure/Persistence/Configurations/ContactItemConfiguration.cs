using jCoreDemoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jCoreDemoApp.Infrastructure.Persistence.Configurations
{
    public class ContactItemConfiguration : IEntityTypeConfiguration<ContactItem>
    {
        public void Configure(EntityTypeBuilder<ContactItem> builder)
        {
            builder.Ignore(e => e.DomainEvents);

            builder.Property(t => t.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}