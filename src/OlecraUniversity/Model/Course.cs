using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlecraUniversity.Models
{
    public class Course
    {
        // This attribute lets you enter the primary key for the course rather
        // than the database generate it
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5, ErrorMessage = "{0} valid input is from {1} to {2}")]
        public int Credits { get; set; }

        // Foreign Key
        public int DepartmentID { get; set; }

        // Navigation properties
        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Instructor> Instructors { get; set; }
    }
}