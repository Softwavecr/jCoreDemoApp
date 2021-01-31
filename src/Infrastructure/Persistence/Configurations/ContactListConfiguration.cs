using jCoreDemoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace jCoreDemoApp.Infrastructure.Persistence.Configurations
{
    public class ContactListConfiguration : IEntityTypeConfiguration<ContactList>
    {
        public void Configure(EntityTypeBuilder<ContactList> builder)
        {
            builder.Property(t => t.Title)
                .HasMaxLength(200)
                .IsRequired();

            builder
                .OwnsOne(b => b.Colour);
        }
    }
}