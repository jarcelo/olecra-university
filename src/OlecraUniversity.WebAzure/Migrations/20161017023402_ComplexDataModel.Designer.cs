using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using OlecraUniversity.WebAzure.Data;

namespace OlecraUniversity.WebAzure.Migrations
{
    [DbContext(typeof(SchoolContext))]
    [Migration("20161017023402_ComplexDataModel")]
    partial class ComplexDataModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Course", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("Credits");

                    b.Property<int>("DepartmentID");

                    b.Property<string>("Title")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("CourseID");

                    b.HasIndex("DepartmentID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.CourseAssignment", b =>
                {
                    b.Property<int>("CourseID");

                    b.Property<int>("InstructorID");

                    b.HasKey("CourseID", "InstructorID");

                    b.HasIndex("CourseID");

                    b.HasIndex("InstructorID");

                    b.ToTable("CourseAssignment");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<int?>("InstructorID");

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("StartDate");

                    b.HasKey("DepartmentID");

                    b.HasIndex("InstructorID");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CourseID");

                    b.Property<int?>("Grade");

                    b.Property<int>("StudentID");

                    b.HasKey("EnrollmentID");

                    b.HasIndex("CourseID");

                    b.HasIndex("StudentID");

                    b.ToTable("Enrollment");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Instructor", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<DateTime>("HireDate");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ID");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.OfficeAssignment", b =>
                {
                    b.Property<int>("InstructorID");

                    b.Property<string>("Location")
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("InstructorID");

                    b.HasIndex("InstructorID")
                        .IsUnique();

                    b.ToTable("OfficeAssignment");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("EnrollmentDate");

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasColumnName("FirstName")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasAnnotation("MaxLength", 50);

                    b.HasKey("ID");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Course", b =>
                {
                    b.HasOne("OlecraUniversity.WebAzure.Models.Department", "Department")
                        .WithMany("Courses")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.CourseAssignment", b =>
                {
                    b.HasOne("OlecraUniversity.WebAzure.Models.Course", "Course")
                        .WithMany("Assignments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OlecraUniversity.WebAzure.Models.Instructor", "Instructor")
                        .WithMany("Courses")
                        .HasForeignKey("InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Department", b =>
                {
                    b.HasOne("OlecraUniversity.WebAzure.Models.Instructor", "Administrator")
                        .WithMany()
                        .HasForeignKey("InstructorID");
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.Enrollment", b =>
                {
                    b.HasOne("OlecraUniversity.WebAzure.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("OlecraUniversity.WebAzure.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("OlecraUniversity.WebAzure.Models.OfficeAssignment", b =>
                {
                    b.HasOne("OlecraUniversity.WebAzure.Models.Instructor", "Instructor")
                        .WithOne("OfficeAssignment")
                        .HasForeignKey("OlecraUniversity.WebAzure.Models.OfficeAssignment", "InstructorID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
