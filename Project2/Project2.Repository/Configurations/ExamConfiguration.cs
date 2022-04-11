using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project2.Core.Entities;

namespace Project2.Repository.Configurations
{
    public class ExamConfiguration:IEntityTypeConfiguration<Exam>
    {
        public void Configure(EntityTypeBuilder<Exam> builder)
        {
            builder.ToTable("Exams");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.LessonCode).IsRequired().HasColumnType("char").HasMaxLength(3);
            builder.Property(x => x.StudentId).IsRequired();
            builder.Property(x => x.ExamDate).IsRequired();
            builder.Property(x => x.Score).IsRequired();
            builder.HasOne(x => x.Lesson).WithMany(x => x.Exams);
            builder.HasOne(x => x.Student).WithMany(x => x.Exams);
        }
    }
}