using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVCApplication.Models;

namespace WebMVCApplication.Configurations
{
    public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.Id);
            builder.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(i => i.Address)
                .HasMaxLength(200);
            builder.Property(i => i.Image)
                .HasMaxLength(500);
            builder.HasOne(i => i.Department)
                .WithMany(d => d.Instructors)
                .HasForeignKey(i => i.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(i => i.Course)
                .WithMany(c => c.Instructors)
                .HasForeignKey(i => i.CourseId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
                            new Instructor
                            {
                                Id = 1,
                                Name = "Ahmed Hassan",
                                Image = "product1.jpeg",
                                Address = "Cairo",
                                Salary = 15000,
                                CourseId = 1,
                                DepartmentId = 1
                            },
                            new Instructor
                            {
                                Id = 2,
                                Name = "Sara Ali",
                                Image = "product2.jpeg",
                                Address = "Alex",
                                Salary = 18000,
                                CourseId = 2,
                                DepartmentId = 1
                            }
                        );
        }
    }
}
