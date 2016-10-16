using System.ComponentModel.DataAnnotations;

namespace OlecraUniversity.WebAzure.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        // Primary Key
        public int EnrollmentID { get; set; }

        // Foreign Keys
        public int CourseID { get; set; }
        public int StudentID { get; set; }

        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; }

        // Navigation properties
        // An enrollment entity is associated with ONE course and student entities
        public Course Course { get; set; }
        public Student Student { get; set; }

    }
}