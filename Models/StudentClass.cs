using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Asp_Labb2.Models
{
    public class StudentClass
    {
        [Key]
        public int StudentClassId { get; set; }
        public string StudentClassName { get; set; }
        public virtual ICollection<Student>? Students { get; set; }

    }
}
