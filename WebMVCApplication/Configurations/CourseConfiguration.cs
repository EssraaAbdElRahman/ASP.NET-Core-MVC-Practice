using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVCApplication.Models;

namespace WebMVCApplication.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(c => c.Degree)
                .IsRequired()
                .HasColumnType("float");
            builder.Property(c => c.MinDegree)
                .IsRequired()
                .HasColumnType("float");
            builder.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new Course
                {
                    Id = 1,
                    Name = "C#",
                    Degree = 100,
                    MinDegree = 60,
                    DepartmentId = 1
                },
                new Course
                {
                    Id = 2,
                    Name = "SQL Server",
                    Degree = 100,
                    MinDegree = 60,
                    DepartmentId = 1
                },
                new Course
                {
                    Id = 3,
                    Name = "Machine Learning",
                    Degree = 100,
                    MinDegree = 50,
                    DepartmentId = 3
                }
            );
        }
    }
}