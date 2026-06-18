using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebMVCApplication.Models;

namespace WebMVCApplication.Configurations
{
    public class TraineeConfiguration : IEntityTypeConfiguration<Trainee>
    {
        public void Configure(EntityTypeBuilder<Trainee> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(t => t.Degree)
                .IsRequired()
                .HasColumnType("float");
          builder.Property(t => t.Address)
                 .HasMaxLength(200);
            builder.Property(t => t.Image)
                .HasMaxLength(500);
            builder.HasOne(t => t.Department)
                .WithMany(d => d.Trainees)
                   .HasForeignKey(t => t.DepartmentId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasData(
                            new Trainee
                            {
                                Id = 1,
                                Name = "Omar",
                                Image = "product1.jpeg",
                                Address = "Tanta",
                                Degree = 90,
                                DepartmentId = 1
                            },
                            new Trainee
                            {
                                Id = 2,
                                Name = "Mona",
                                Image = "product2.jpeg",
                                Address = "Mansoura",
                                Degree = 85,
                                DepartmentId = 3
                            }
                        );
        }
    }
}
