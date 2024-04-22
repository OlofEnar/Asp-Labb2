using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace Asp_Labb2.Models
{
    public enum Grade
    {
        UNSET,IG,G,VG,MVG
    }

    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public Grade? Grade { get; set; }
        [ForeignKey("Course")]
        public int FkCourseId { get; set; }
        [ForeignKey("Student")]
        public int FkStudentId { get; set; }
        public virtual Course? Course { get; set; }
        public virtual Student? Student { get; set; }
        [ForeignKey("Teacher")]
        public int FkTeacherId { get; set; }
        public virtual Teacher? Teacher { get; set; }
    }
}
