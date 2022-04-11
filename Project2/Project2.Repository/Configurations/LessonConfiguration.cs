using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project2.Core.Entities;

namespace Project2.Repository.Configurations
{
    public class LessonConfiguration:IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.ToTable("Lessons");

            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code).IsRequired().HasColumnType("char").HasMaxLength(3);
            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar").HasMaxLength(30);
            builder.Property(x => x.Class).IsRequired();
            builder.Property(x => x.TeacherName).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.Property(x => x.TeacherSurname).IsRequired().HasColumnType("varchar").HasMaxLength(20);
            builder.HasMany(x => x.Exams).WithOne(x => x.Lesson);

        }
    }
}