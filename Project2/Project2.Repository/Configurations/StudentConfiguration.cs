using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project2.Core.Entities;

namespace Project2.Repository.Configurations
{
    public class StudentConfiguration:IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable("Students");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Surname).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Class).IsRequired();
            builder.HasMany(x => x.Exams).WithOne(x => x.Student);
        }
    }
}