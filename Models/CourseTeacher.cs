using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Asp_Labb2.Models
{
    public class CourseTeacher
    {
        [Key]
        public int CourseTeacherId { get; set; }
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        [ForeignKey("StudentClass")]
        public int FkStudentClassId { get; set; }

        public virtual Course? Course { get; set; }
        public virtual Teacher? Teacher { get; set; }
        public virtual StudentClass? StudentClass { get; set; }
    }
}
