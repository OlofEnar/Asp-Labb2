using System.ComponentModel.DataAnnotations;

namespace Asp_Labb2.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public virtual ICollection<Enrollment>? Enrollment { get; set; }

    }
}

