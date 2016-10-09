using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OlecraUniversity.Models
{
    public class Instructor : Person
    {
        //public int ID { get; set; }

        //[Required]
        //[Display (Name = "Last Name")]
        //[StringLength(50)]
        //public string LastName { get; set; }

        //[Required]
        //[Column("FirstName")]
        //[Display(Name = "First Name")]
        //[StringLength(50)]
        //public string FirstMidName { get; set; }

        ///// <summary>
        ///// Concatenates the last name and first/middle name
        ///// </summary>
        //public string FullName
        //{
        //    get
        //    {
        //        return LastName + ", " + FirstMidName;
        //    }
        //}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name ="Hire Date")]
        public DateTime HireDate { get; set; }

        // Navigation properties
        public virtual ICollection<Course> Courses { get; set; }
        public virtual OfficeAssignment OfficeAssignment { get; set; }
    }
}