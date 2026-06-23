
namespace WebMVCApplication.Models
{
    public class CourseResult
    {
        public int Id { get; set; }
        public double Degree { get; set; }
        public int CourseId { get; set; }
        public int TraineeId     { get; set; }
        public Course Course { get; set; } 
        public Trainee Trainee { get; set; } 

    }
}
