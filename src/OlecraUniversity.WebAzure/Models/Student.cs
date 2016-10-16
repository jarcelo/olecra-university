using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace OlecraUniversity.WebAzure.Models
{
    public class Student
    {
        // Primary Key
        public int ID { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(50, ErrorMessage = "{0} cannot be longer than {1} characters")]
        [Column("FirstName")]
        public string FirstMidName { get; set; }

        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date, ErrorMessage = "{0} must be in MM/DD/YYY format" )]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode =true)]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }

        // Navigation Property 
        // There's one to many relationship between Student and Enrollment
        public virtual ICollection<Enrollment> Enrollments { get; set; }
    }

}