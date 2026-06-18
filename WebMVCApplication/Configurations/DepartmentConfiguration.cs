using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVCApplication.Models;

namespace WebMVCApplication.Configurations
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.Manager)
                .IsRequired()
                .HasMaxLength(100);
            builder.HasData(
                           new Department
                           {
                               Id = 1,
                               Name = "SD",
                               Manager = "Ahmed"
                           },
                           new Department
                           {
                               Id = 2,
                               Name = "OS",
                               Manager = "Mohamed"
                           },
                           new Department
                           {
                               Id = 3,
                               Name = "AI",
                               Manager = "Ali"
                           }
                       );
        }
    }
}
