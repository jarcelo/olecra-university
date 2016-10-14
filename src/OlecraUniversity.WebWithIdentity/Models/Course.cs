using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlecraUniversity.WebWithIdentity.Models
{
    public class Course
    {
        // The DatabaseGenerated attribute lets the user enter the primary key for the course rather than having
        // the database auto generate it
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Number")]
        public int CourseID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Range(0, 5, ErrorMessage = "{0} valid input is from {1} to {2}")]
        public int Credits { get; set; }

        public int DepartmentID { get; set; }


        // Navigation properties
        public Department Department { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
        public ICollection<CourseAssignment> Assignments { get; set; }
    }
}