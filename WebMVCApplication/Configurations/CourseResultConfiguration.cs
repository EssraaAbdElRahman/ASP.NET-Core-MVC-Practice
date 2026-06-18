using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVCApplication.Models;

namespace WebMVCApplication.Configurations
{
    public class CourseResultConfiguration : IEntityTypeConfiguration<CourseResult>
    {
        public void Configure(EntityTypeBuilder<CourseResult> builder)
        {
           builder.HasKey(cr => cr.Id);
            builder.Property(cr => cr.Degree)
                .IsRequired()
                .HasColumnType("float");
            builder.HasOne(cr => cr.Course)
                .WithMany(c => c.CourseResults)
                .HasForeignKey(cr => cr.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(cr => cr.Trainee)
                .WithMany(t => t.CourseResults)
                .HasForeignKey(cr => cr.TraineeId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
                            new CourseResult
                            {
                                Id = 1,
                                Degree = 95,
                                CourseId = 1,
                                TraineeId = 1
                            },
                            new CourseResult
                            {
                                Id = 2,
                                Degree = 88,
                                CourseId = 3,
                                TraineeId = 2
                            }
                        );
        }
    }
}
