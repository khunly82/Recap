using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Recap.Domain.Entities;

namespace Recap.DAL.Configurations
{
    internal class CalendarEventConfiguration : IEntityTypeConfiguration<CalendarEvent>
    {
        public void Configure(EntityTypeBuilder<CalendarEvent> builder)
        {
            builder.ToTable("Events");

            builder.HasKey(e => e.Id);

            builder
                .Property(e => e.Title)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            builder
                .Property(e => e.Start)
                .IsRequired()
                .HasColumnType("DATE");

            builder
                .Property(e => e.End)
                .HasColumnType("DATE");
        }
    }
}
