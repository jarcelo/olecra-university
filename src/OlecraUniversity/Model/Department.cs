using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OlecraUniversity.Models
{
    public class Department
    {
        public int DepartmentID { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Display(Name = "Dept. Name")]
        public string Name { get; set; }

        [DataType(DataType.Currency)]
        // This attribute is being used to change SQL data type mapping so that the column will be defined using the SQL Server money type in the database
        [Column(TypeName = "money")]
        public decimal Budget { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "Administrator")]
        public int? InstructorID { get; set; }

        // The timestamp attribute specifies that this column will be included in the Where clause of Update and Delete
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public virtual Instructor Administrator { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}