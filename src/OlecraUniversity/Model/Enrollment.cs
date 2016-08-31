using System.ComponentModel.DataAnnotations;

namespace ContosoUniv.Models
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

        // Question mark means that this is nullable
        // Null means it is not known or hasn't been assigned yet
        [DisplayFormat(NullDisplayText = "No Grade")]
        public Grade? Grade { get; set; } 

        // Navigation properties
        // An enrollment entity is associated with one course and student entities
        public virtual Course Course { get; set; }
        public virtual Student Student { get; set; }

    }
}