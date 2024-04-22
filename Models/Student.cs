using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_Labb2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string StudentName { get; set;}
        [ForeignKey("StudentClass")]
        [Required]
        public int FkStudentClassId { get; set; }
        public StudentClass? StudentClass { get; set; }
        public virtual ICollection<Enrollment>? Enrollments { get; set; }

    }
}
