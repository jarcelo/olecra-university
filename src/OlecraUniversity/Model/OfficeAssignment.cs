using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniv.Models
{
    public class OfficeAssignment
    {
        [Key] // Use this attribute to explicitly tell EF that this is the primary key.
        [ForeignKey("Instructor")] // Applied to this dependent class to establish a relationship.
        public int InstructorID { get; set; }

        [StringLength(50)]
        [Display(Name = "Office Location")]
        public string Location { get; set; }

        // Navigation property
        // Instructor and OfficeAssignment have one-to-zero-or-one relationship
        public virtual Instructor Instructor { get; set; }
    }
}